using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class FootStepper : MonoBehaviour {

	public GameObject playerBody;
	Rigidbody rb;
	bool movingNow;

	public float howOftenToStep = .2f;
	float lastTimeStepped = 0f;

	AudioSource linoStep1;
	AudioSource linoStep2;
	AudioSource linoStep3;
	AudioSource linoStep4;
	AudioSource linoStep5;
	AudioSource linoStep6;

	int steppoNum;

	// Use this for initialization
	void Start(){

		rb = playerBody.GetComponent<Rigidbody> ();

		AudioSource[] aSources = GetComponents<AudioSource>();
		linoStep1 = aSources[0];
		linoStep2 = aSources[1];
		linoStep3 = aSources[2];
		linoStep4 = aSources[3];
		linoStep5 = aSources[4];
		linoStep6 = aSources[5];
	
	}
	
	// Update is called once per frame
	void Update () {
		
		steppoNum = Random.Range (0, 6);
		if (rb.velocity.magnitude > 0) {
			//lastTimeStepped = Time.time;
			movingNow = true;
		} else {
			movingNow = false;
		}

		if ((Time.time - lastTimeStepped > howOftenToStep) && (movingNow == true)) { 
			if (steppoNum == 0) 
			{
				linoStep1.Play();
			}
			if (steppoNum == 1) 
			{
				linoStep2.Play();
			}
			if (steppoNum == 2) 
			{
				linoStep3.Play();
			}
			if (steppoNum == 3) 
			{
				linoStep4.Play();
			}
			if (steppoNum == 4) 
			{
				linoStep5.Play();
			}
			if (steppoNum == 5) 
			{
				linoStep6.Play();
			}
			lastTimeStepped = Time.time;
		}
		
	}
}
