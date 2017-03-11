using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceAmplitude : MonoBehaviour {

	[SerializeField]private uint sampleAmount = 1;
	private float[] samples;
	//assign this in the inspector
	private AudioSource mAudioSource;
	public float myVolume; 


	void Awake(){
		samples= new float[sampleAmount];
		mAudioSource = gameObject.GetComponent<AudioSource>();
	}

	float GetVolumeThisFrame(){
		if (mAudioSource.isPlaying){
			int sampleOffsetTime = mAudioSource.timeSamples;

			mAudioSource.clip.GetData(samples, sampleOffsetTime);
			float loudness = Mathf.Abs(samples[0]) * mAudioSource.volume;
			//return samples[0];
			return loudness; 
		}
		return 0;
	}

	void Update() {
		myVolume = GetVolumeThisFrame ();
		//print (myVolume);
	}
}
