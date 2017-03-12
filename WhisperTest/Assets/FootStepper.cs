using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepper : MonoBehaviour {


	AudioSource linoStep1;
	AudioSource linoStep2;
	AudioSource linoStep3;

	// Use this for initialization
	void Start(){

		AudioSource[] aSources = GetComponents<AudioSource>();
		linoStep1 = aSources[0];
		linoStep2 = aSources[1];
		linoStep3 = aSources[2];

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
