using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractableObjectController : MonoBehaviour
{

    bool CanInteract;
    GameObject player;
    Mesh CurrItem;
    public OutlineSystem OutlineSystem;
    bool ToLerp;
    GameObject Focused;
    // Use this for initialization
    void Awake()
    { }

    void Start()
    {
        //To get mouse down events on triggers
        Physics.queriesHitTriggers = true;
        CanInteract = false;
        CurrItem = null;
        ToLerp = false;
        OutlineSystem.outlineStrength = 0.0f;
        Focused = null;
        this.GetComponent<RotateObjectController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ToLerp)
        {
            //Debug.Log("LERPING TO 0.5");
            OutlineSystem.outlineStrength = Mathf.Lerp(0.5f, 0.0f, Time.deltaTime * 0.3f);
        }
        else
        {
           // Debug.Log("LERPING TO 0");
            OutlineSystem.outlineStrength = Mathf.Lerp(0.0f, 0.5f, Time.deltaTime * 0.3f);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        //In case we have object to object collisions in the future might as well check this
        if (other.tag == "Player")
        {
            //Make Outline
            Debug.Log("TRIGGER");
            CanInteract = true;
        }
    }
    public void OnTriggerExit()
    {
        //Disable Outline
        CanInteract = false;
        ToLerp = false;
    }
    public void Interact()
    {
        if (!CurrItem)
        {
            CurrItem = this.GetComponent<MeshFilter>().mesh;
            Spawn();
        }
    }

    void OnMouseDown()
    {
        if (CanInteract)
        {
            Debug.Log("Interact");
            Interact();
        }
    }
    void Spawn()
    {
        //Spawn rotatable object (build prefab for that)
        if (!Focused)
        {
            //Object is now a rotatable object NOT interactable
            //this.GetComponent<RotateObjectController>().Player = this.player;
            this.GetComponent<RotateObjectController>().enabled = true;
            
            this.GetComponent<InteractableObjectController>().enabled = false;
        }
       // Focused = Instantiate(, SpawnPoint.position, Quaternion.Euler(0.0f, 45.0f, 0.0f));
        
    }
    void OnMouseOver()
    {
        if(CanInteract)
            ToLerp = true;
    }
    void OnMouseExit()
    {
       // if (CanInteract)
            ToLerp = false;
    }
    void DestroyFocused()
    {
        if (Focused)
        {
            //Destroy(Focused);

        }
           
    }
}
