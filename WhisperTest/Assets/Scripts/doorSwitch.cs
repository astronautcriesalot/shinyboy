using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSwitch : MonoBehaviour {

	public GameObject switchTrigger;
	public bool switchTriggerOccupied;
	public bool whichPos = true;

	AudioSource doorSwitchAudio;

	public float speed = 5F;
	public float posOne = 289F;
	public float posTwo = 109F;

	// Use this for initialization
	void Start () {

		doorSwitchAudio = gameObject.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

		switchTriggerOccupied = switchTrigger.GetComponent<doorTrigger> ().triggerOccupied;

		if (switchTriggerOccupied) {
			doorSwitchAudio.Play ();
		}

		if (switchTriggerOccupied && whichPos == true) {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, posOne, 0), Time.deltaTime * speed);
		}
			
		if (switchTriggerOccupied && whichPos == false) {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, posTwo, 0), Time.deltaTime * speed);
		}



		if (switchTrigger.GetComponent<doorTrigger>().triggerExit == true) {
			whichPos = !whichPos;
		}


		switchTrigger.GetComponent<doorTrigger> ().triggerExit = false;				
	}
}
