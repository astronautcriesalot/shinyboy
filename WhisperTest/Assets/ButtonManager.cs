using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour {

    bool hitaButton = false;
    public int ButtonValue;
    public bool rayHit = false;
    public delegate void ButtonClick(int value);
    public static event ButtonClick OnButtonClick;
    // Use this for initialization
    void Start () {
        Physics.queriesHitTriggers = true;
	}
	// Update is called once per frame
	void Update () {

    }

    void OnMouseEnter()
    {
        gameObject.layer = 1;
        
        Debug.Log("CAN INTERACT WITH BUTTON: " + ButtonValue);
    }
    void OnMouseExit()
    {
        gameObject.layer = 10;
    }
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnButtonClick(ButtonValue);
        }
    }
}
