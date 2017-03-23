using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionZoomScript : MonoBehaviour {

	Camera mainCam;

	float zoomedOutFOV = 60f;
	float zoomedInFOV = 30f;

	// Use this for initialization
	void Start () {

		mainCam = gameObject.GetComponent<Camera> ();
		mainCam.fieldOfView = zoomedOutFOV;
		
	}
	
	// Update is called once per frame
	void Update () {

	
		
	}
}
