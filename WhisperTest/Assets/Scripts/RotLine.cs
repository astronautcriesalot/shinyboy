using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotLine : MonoBehaviour {

	GameObject player; 
	RectTransform rect;

	public float yRot;
	public float originalXPos;
	public float xPos;
	float offset;
	public float scalar;


	// Use this for initialization
	void Start () {

		player = GameObject.Find ("RigidBodyFPSController");
		rect = gameObject.GetComponent<RectTransform> ();

		originalXPos = rect.position.x;

	}
	
	// Update is called once per frame
	void Update () {
	 	
		yRot = player.transform.eulerAngles.y;

		offset = (yRot / 360) * scalar;
		xPos = originalXPos + offset;
		Vector3 newPos = new Vector3 (xPos, rect.position.y, rect.position.z);

		rect.position = newPos;

	}
}
