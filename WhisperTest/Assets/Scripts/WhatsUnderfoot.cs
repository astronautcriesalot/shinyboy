using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatsUnderfoot : MonoBehaviour {

	public bool puddleUnderfoot = false; 
	public bool grateUnderfoot = false;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Puddle") {
			puddleUnderfoot = true;
		}

		if (other.tag == "Grate") {
			grateUnderfoot = true;
		}

	}

	void OnTriggerExit(Collider other) 
	{
		if (other.tag == "Puddle") {
			puddleUnderfoot = false;
		}

		if (other.tag == "Grate") {
			grateUnderfoot = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
