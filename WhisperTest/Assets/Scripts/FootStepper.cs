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

	AudioSource puddleStep1;
	AudioSource puddleStep2;
	AudioSource puddleStep3;
	AudioSource puddleStep4;
	AudioSource puddleStep5;
	AudioSource puddleStep6;

	AudioSource grateStep1;
	AudioSource grateStep2;
	AudioSource grateStep3;
	AudioSource grateStep4;
	AudioSource grateStep5;
	AudioSource grateStep6;

	int steppoNum;

	public bool puddleTime;
	public bool grateTime;

	// Use this for initialization
	void Start(){

		rb = playerBody.GetComponent<Rigidbody> ();

		AudioSource[] aSources = GetComponents<AudioSource>();
		//regular
		linoStep1 = aSources[0];
		linoStep2 = aSources[1];
		linoStep3 = aSources[2];
		linoStep4 = aSources[3];
		linoStep5 = aSources[4];
		linoStep6 = aSources[5];
		//puddle
		puddleStep1 = aSources[6];
		puddleStep2 = aSources[7];
		puddleStep3 = aSources[8];
		puddleStep4 = aSources[9];
		puddleStep5 = aSources[10];
		puddleStep6 = aSources[11];
		//grate
		grateStep1 = aSources[12];
		grateStep2 = aSources[13];
		grateStep3 = aSources[14];
		grateStep4 = aSources[15];
		grateStep5 = aSources[16];
		grateStep6 = aSources[17];
	
	}
		
	// Update is called once per frame
	void Update () {

		puddleTime = playerBody.GetComponent<WhatsUnderfoot> ().puddleUnderfoot;
		grateTime = playerBody.GetComponent<WhatsUnderfoot> ().grateUnderfoot;
		
		steppoNum = Random.Range (0, 6);
		if (rb.velocity.magnitude > 0) {
			//lastTimeStepped = Time.time;
			movingNow = true;
		} else {
			movingNow = false;
		}

		if ((Time.time - lastTimeStepped > howOftenToStep) && (movingNow == true)) { 

			if (puddleTime == true) {

				if (steppoNum == 0) {
					puddleStep1.Play ();
					//linoStep1.Play ();
				}
				if (steppoNum == 1) {
					puddleStep2.Play ();
					//linoStep2.Play ();
				}
				if (steppoNum == 2) {
					puddleStep3.Play ();
					//linoStep3.Play ();
				}
				if (steppoNum == 3) {
					puddleStep4.Play ();
					//linoStep4.Play ();
				}
				if (steppoNum == 4) {
					puddleStep5.Play ();
					//linoStep5.Play ();
				}
				if (steppoNum == 5) {
					puddleStep6.Play ();
					//linoStep6.Play ();
				}

			} else if (grateTime == true) {

				if (steppoNum == 0) {
					grateStep1.Play ();
					//linoStep1.Play ();
				}
				if (steppoNum == 1) {
					grateStep2.Play ();
					//linoStep2.Play ();
				}
				if (steppoNum == 2) {
					grateStep3.Play ();
					//linoStep3.Play ();
				}
				if (steppoNum == 3) {
					grateStep4.Play ();
					//linoStep4.Play ();
				}
				if (steppoNum == 4) {
					grateStep5.Play ();
					//linoStep5.Play ();
				}
				if (steppoNum == 5) {
					grateStep6.Play ();
					//linoStep6.Play ();
				}

			} else {

				if (steppoNum == 0) {
					linoStep1.Play ();
				}
				if (steppoNum == 1) {
					linoStep2.Play ();
				}
				if (steppoNum == 2) {
					linoStep3.Play ();
				}
				if (steppoNum == 3) {
					linoStep4.Play ();
				}
				if (steppoNum == 4) {
					linoStep5.Play ();
				}
				if (steppoNum == 5) {
					linoStep6.Play ();
				}

			}

			lastTimeStepped = Time.time;
		}
		
	}
}
