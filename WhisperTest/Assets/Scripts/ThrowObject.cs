using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject: MonoBehaviour 
{
	public Transform player;
	public Transform playerCam;
	public float throwForce = 10;
	bool hasPlayer = false;
	bool beingCarried = false;
	public AudioClip[] soundToPlay;
	private AudioSource audio;
	public int dmg;
	private bool touched = false;
	public bool sticky = false; 
	public bool rayHit = false;
	public bool hitAnInteractable = false;

	void Start()
	{
		audio = GetComponent<AudioSource>();
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		gameObject.layer = 8;
	}

	void Update()
	{
		hitAnInteractable= playerCam.GetComponent<CameraRay> ().hitAnInteractable;

		float dist = Vector3.Distance(gameObject.transform.position, player.position);
		if (dist <= 2f)
		{
			if (rayHit == true) {
				hasPlayer = true;
				gameObject.layer = 1;
			}
		}

		if (!rayHit)
		{
			hasPlayer = false;
			gameObject.layer = 8;
		}


		if (hasPlayer && Input.GetKeyDown(KeyCode.E))
		{
			GetComponent<Rigidbody>().isKinematic = true;
			transform.parent = playerCam;
			beingCarried = true;
		}
		if (beingCarried)
		{
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			if (touched)
			{
				GetComponent<Rigidbody>().isKinematic = false;
				transform.parent = null;
				beingCarried = false;
				touched = false;
			}
			// if (Input.GetMouseButtonDown(0))
			//{
			// GetComponent<Rigidbody>().isKinematic = false;
			// transform.parent = null;
			// beingCarried = false;
			// GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
			//RandomAudio();
			// }
			// else 
			if (Input.GetMouseButtonDown(1))
			{
				GetComponent<Rigidbody>().isKinematic = false;
				transform.parent = null;
				beingCarried = false;
			}
		}
		if (!beingCarried) 
		{
			if(sticky == true)
			{
				GetComponent<Rigidbody>().useGravity = false;
				transform.rotation = Quaternion.identity;
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;;
			}
		}

		rayHit = false;

	}

	void RandomAudio()
	{
		if (audio.isPlaying){
			return;
		}
		audio.clip = soundToPlay[Random.Range(0, soundToPlay.Length)];
		audio.Play();

	}
	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Sticky") {
			sticky = true;
		}

		if (beingCarried)
		{
			touched = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Sticky") {
			sticky = false;
		}
	}

}