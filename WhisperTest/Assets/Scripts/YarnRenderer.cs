using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YarnRenderer : MonoBehaviour {

	private LineRenderer lr;
	public int currentPosition = 0;

	// Use this for initialization
	void Start () {

		lr = GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Sprites/Default"));

		Vector3[] positions = new Vector3[5];
		positions[0] = new Vector3(-30f, 1f, 15f);
		positions[1] = new Vector3(-30f, 1f, 15f);
		positions[2] = new Vector3(-30f, 1f, 15f);
		positions[3] = new Vector3(-30f, 1f, 15f);
		positions[4] = new Vector3(-30f, 1f, 15f);
		lr.numPositions = positions.Length;
		lr.SetPositions (positions);

	}
	
	// Update is called once per frame
	void Update () {

		if (currentPosition > 4) {
			currentPosition = 0;
		}
		

	}
}
