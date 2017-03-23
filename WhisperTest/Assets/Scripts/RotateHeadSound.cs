using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHeadSound : MonoBehaviour
{

    [SerializeField]
    AudioSource yRotateAudio;
    [SerializeField]
    AudioSource xRotateAudio;

    public float pitchAdjuster = 20.0f;
    public float volAdjuster = 10.0f;

    public float maxPitch = 2f;
    public float maxVol = 0.5f;

    List<float> xDeltaHistory = new List<float>();
    List<float> yDeltaHistory = new List<float>();
    int HISTORY_LENGTH = 96;

    Transform mPlayer;
    Transform mCamera;

    float lastFrameYRot;
    float lastFrameXRot;

    // Use this for initialization
    void Start()
    {
        if (yRotateAudio == null) Debug.LogWarning("AudioSource for head y rotate not attached");
        if (xRotateAudio == null) Debug.LogWarning("AudioSource for head x rotate not attached");

        mPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        lastFrameYRot = mPlayer.eulerAngles.y;
        mCamera = Camera.main.transform;
        lastFrameXRot = mCamera.eulerAngles.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // get current frame of rotation
        float yRot = mPlayer.eulerAngles.y;
        float xRot = mCamera.eulerAngles.x;

        // get the difference of rotation between this frame and last frame
        float yDiff = FindDifference(lastFrameYRot, yRot);
        float xDiff = FindDifference(lastFrameXRot, xRot);

        //update last frame to this frame
        lastFrameXRot = xRot;
        lastFrameYRot = yRot;


        // add differences to history;
        xDeltaHistory.Add(xDiff);
        yDeltaHistory.Add(yDiff);
        if (xDeltaHistory.Count >= HISTORY_LENGTH) xDeltaHistory.RemoveAt(0);
        if (yDeltaHistory.Count >= HISTORY_LENGTH) yDeltaHistory.RemoveAt(0);

        // set speed as average of the past 48 changes in rotation
        float ySpeed = 0.0f;
        float xSpeed = 0.0f;
        foreach (float delta in xDeltaHistory) xSpeed += delta;
        foreach (float delta in yDeltaHistory) ySpeed += delta;
        ySpeed = ySpeed / yDeltaHistory.Count;
        xSpeed = xSpeed / xDeltaHistory.Count;

        // set pitch and vol based on rotation speed
        yRotateAudio.pitch = Mathf.Clamp(0.5f + ySpeed / pitchAdjuster, 1.0f, maxPitch);
        yRotateAudio.volume = Mathf.Clamp(yDiff / volAdjuster, 0f, maxVol);

        xRotateAudio.pitch = Mathf.Clamp(0.5f + (xSpeed / pitchAdjuster), 1.0f, maxPitch);
        xRotateAudio.volume = Mathf.Clamp(xDiff / volAdjuster, 0f, maxVol);
    }


    float FindDifference(float lastFrame, float thisFrame)
    {
        //this is a bit of a hacky solution, but it works, so it's not hacky
        float delta = Mathf.Abs(thisFrame - lastFrame);
        if (delta >= 300) delta = 360 - delta;
        // so when the rotation pops over the
        // point where it goes from 0 to 360 or vice versa
        // we just do a check to see if it's an absurd number
        // and if it is, math happens to make it the right number

        return delta;
    }

}
