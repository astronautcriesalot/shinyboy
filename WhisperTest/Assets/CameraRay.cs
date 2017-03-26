﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour {

	Camera camera;
	public bool hitAnInteractable = false;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(new Vector3(500, 300, 0));
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				//Debug.Log ("hit anything??");
				//hit.collider.enabled = false;
				if (hit.collider.tag == "Interactable") {
					hitAnInteractable = true;
					hit.collider.GetComponent<ThrowObject> ().rayHit = true;
				} else {
					hitAnInteractable = false;
				}
			}
		}


			
	}
}
