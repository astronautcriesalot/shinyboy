﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockManager : MonoBehaviour {

    public int Password;
    int Acc = 0;
    int howmany = 0;
    bool SlideDoor = false;
    GameObject door;
    Text disp;
    // Use this for initialization
    void Start() {
        //subscribe event
        ButtonManager.OnButtonClick += OnAButtonClick;
        door = this.transform.GetChild(1).gameObject;
        disp = this.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        disp.text = "";
    }
    void OnDisable()
    {
        //unsubscribe event
        ButtonManager.OnButtonClick -= OnAButtonClick;
    }

	// Update is called once per frame
	void Update () {
        if (SlideDoor)
        {
            Vector3 pos = door.transform.localPosition;
            float percentage = pos.z/8.0f;
            pos.z = Mathf.Lerp(3.0f, 8.0f,percentage);
            door.transform.localPosition = pos;
        }
	}
    void OnAButtonClick(int val)
    {
        if(howmany == 0)
        {
            disp.text = "";
        }
        ++howmany;
        //Debug.Log("How many received " + howmany);
        if (howmany <3)
        {
            if(howmany == 1)
            {
                Acc += val;
            }
            else
            {
                Acc *= 10;
                Acc += val;
            }
            disp.text = Acc + " ";
            Debug.Log("Accumlated Password: " + Acc);
        }
        else
        {
            Acc *= 10;
            Acc += val;
            Debug.Log("Password: " + Acc);
            if (Acc == Password) {
                TurnToGreen();
                ButtonManager.OnButtonClick -= OnAButtonClick;
            }
            else
            {
                howmany = 0;
                Acc = 0;
                TurnToRed();
                
                //Play a wrong sound here
            }
        }
        
    }

    void TurnToGreen()
    {
        GameObject go = this.transform.GetChild(0).gameObject;
        disp.text = "SUCCESS";
        go.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);
        //open door
        SlideDoor = true; 
    }

    void TurnToRed()
    {
        GameObject go = this.transform.GetChild(0).gameObject;
        disp.text = "INV";
        go.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.red);
    }
}
