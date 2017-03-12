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

	public AudioLowPassFilter lowPass;
	public AudioHighPassFilter highPass;

    void Awake()
    {
        samples = new float[sampleAmount];
        mAudioSource = gameObject.GetComponent<AudioSource>();
        loudnessDataSet = new int[10];
    }

	void Start()
	{
		lowPass = GetComponent<AudioLowPassFilter> ();
		highPass = GetComponent<AudioHighPassFilter> ();

		disableFuzz ();
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
        //print(myVolume);
        //DataTester();
    }


    //stuff for debug
    //void OnApplicationQuit()
    //{
    //    foreach(int i in loudnessDataSet)
    //    {
    //        print(i);
    //    }
    //}
    int[] loudnessDataSet;
    void DataTester()
    {
        if (myVolume >= .9) loudnessDataSet[9]++;
        else if (myVolume >= .8) loudnessDataSet[8]++;
        else if (myVolume >= .7) loudnessDataSet[7]++;
        else if (myVolume >= .6) loudnessDataSet[6]++;
        else if (myVolume >= .5) loudnessDataSet[5]++;
        else if (myVolume >= .4) loudnessDataSet[4]++;
        else if (myVolume >= .3) loudnessDataSet[3]++;
        else if (myVolume >= .2) loudnessDataSet[2]++;
        else if (myVolume >= .1) loudnessDataSet[1]++;
        else if (myVolume >= 0) loudnessDataSet[0]++;

    }

	public void enableFuzz()
	{
		lowPass.enabled = true;
		highPass.enabled = true; 
	}

	public void disableFuzz()
	{
		lowPass.enabled = false;
		highPass.enabled = false; 
	}

}

