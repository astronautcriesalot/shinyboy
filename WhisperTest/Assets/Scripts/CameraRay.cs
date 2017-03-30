using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraRay : MonoBehaviour {

	public Camera camera;
	public bool hitAnInteractable = false;
    public Image reticle;
	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(reticle.transform.position);;
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				Debug.Log ("hit anything??");
				//hit.collider.enabled = false;
				if (hit.collider.GetComponent<ThrowObject>() != null){
				//if (hit.collider.tag == "Sticker") {
					hitAnInteractable = true;
					hit.collider.GetComponent<ThrowObject> ().rayHit = true;
				} else {
					hitAnInteractable = false;
				}
			}
		}


			
	}
}
