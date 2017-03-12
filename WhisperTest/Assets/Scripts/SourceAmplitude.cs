using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceAmplitude : MonoBehaviour
{

    [SerializeField]
    private uint sampleAmount = 1;
    private float[] samples;
    //assign this in the inspector
    private AudioSource mAudioSource;
    public float myVolume;
    public Transform player;


    void Awake()
    {
        samples = new float[sampleAmount];
        mAudioSource = gameObject.GetComponent<AudioSource>();
    }

    float GetVolumeThisFrame()
    {
        if (mAudioSource.isPlaying)
        {
            int sampleOffsetTime = mAudioSource.timeSamples;

            mAudioSource.clip.GetData(samples, sampleOffsetTime);
            float loudness = Mathf.Abs(samples[0]) * mAudioSource.volume;

            //find distance to player
            Vector3 distanceVec = player.position - transform.position;
            float distanceSqr = Vector3.SqrMagnitude(distanceVec);
            //print(Mathf.Sqrt(distanceSqr));
            float maxDistanceSqr = Mathf.Pow(mAudioSource.maxDistance, 2);
            //// the further you are, the smaller the sound, so loudness decreases as distancesq increases.
            float distanceFactor = 1 - (distanceSqr / maxDistanceSqr);
            //print(distanceFactor);
            distanceFactor = Mathf.Clamp(distanceFactor, 0.0f, 1.0f);
            loudness *= distanceFactor; // multiply the loudness based on the distance factor

            //return samples[0];
            return loudness;
        }
        return 0;
    }

    void Update()
    {
        myVolume = GetVolumeThisFrame();
        //print (myVolume);
    }
}

