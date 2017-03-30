using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionTapeOneHalf : MonoBehaviour {

    public GameObject otherHalf;
    public GameObject Tape;
    bool IsBeingCarried;
    bool CanbeCarried;
    Rigidbody rigid;
    float LastScale;
    Transform CTapeParent;
    LineRenderer line;
	// Use this for initialization
	void Start () {
        IsBeingCarried = false;
        rigid = this.GetComponent<Rigidbody>();
        CanbeCarried = false;
        LastScale = 0.0f;
        if (Tape)
        {
            line = Tape.GetComponent<LineRenderer>();
            line.SetPosition(0, this.transform.position);
            line.SetPosition(1, otherHalf.transform.position);
        }
        CTapeParent = this.transform.parent; 
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CanbeCarried)
            {
                rigid.useGravity = false;
                rigid.isKinematic = true;
                this.transform.parent = Camera.main.transform;
                IsBeingCarried = true;
                this.GetComponent<Collider>().enabled = false;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (IsBeingCarried)
            {
                this.GetComponent<Collider>().enabled = true;
                rigid.constraints = RigidbodyConstraints.None;
                rigid.useGravity = true;
                rigid.isKinematic = false;
                transform.parent = CTapeParent;
                IsBeingCarried = false;
            }
        }

        if (IsBeingCarried)
        {
            //manipulate tape in between
            //if this object is moving, manipulate otherhalfs tape
            /*this.transform.GetChild(0).gameObject.SetActive(false);
            GameObject tape = otherHalf.transform.GetChild(0).gameObject;
            tape.SetActive(true);
            float scale = Vector3.Distance(otherHalf.transform.position, this.transform.position);
            float z = tape.transform.position.z;
            if (scale != LastScale)
            {
                var temp = tape.transform.localScale;
                temp.x *= scale;
                tape.transform.localScale = temp;

                var temp2 = tape.transform.position;
                temp2.z = z;
                tape.transform.position = temp2;
                tape.transform.LookAt(this.transform.position);
                LastScale = scale;
            }*/
            if (Tape)
            {
                line.SetPosition(0, this.transform.position);
                line.SetPosition(1, otherHalf.transform.position);
            }
          
            //Tape.transform.LookAt( this.gameObject.transform.forward);
    
        }
        
	}
    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer == 10 && IsBeingCarried)
        {
            Debug.Log("TRIGGER WALL");
            //stick on the wall
            this.transform.parent = CTapeParent;
                rigid.isKinematic = false;
                IsBeingCarried = false;
        }
        if(other.tag == "Player"){
            CanbeCarried = true;
        }
    }
    void OnTriggerExit()
    {
        CanbeCarried = false;
    }

}
