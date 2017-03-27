using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour {

	public bool triggerOccupied = false;
	public bool triggerExit = false;


	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			triggerOccupied = true;
			Debug.Log ("triggered");
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			triggerOccupied = false;
			triggerExit = true;
		}
	}

}
