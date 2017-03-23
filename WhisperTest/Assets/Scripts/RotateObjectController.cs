using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class RotateObjectController : MonoBehaviour
{

    bool isRotating;
    bool CanRotate;
    GameObject Eye_L;
    GameObject Eye_R;
    bool LerpFlag;
    public GameObject EquipPrefab;
    public Transform SpawnPoint;
    public GameObject Player;
    GameObject obj;
    // Use this for initialization
    void Awake()
    { }
    void OnEnable() {
        LerpFlag = true;
        //Move Gameobject up
        this.transform.position = new Vector3(this.transform.position.x,1.5f, this.transform.position.z);
        this.transform.localScale *= 0.4f;
        Player.GetComponent<RigidbodyFirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    void Start()
    {
        //To get mouse down events on triggers
        //Physics.queriesHitTriggers = true;
        CanRotate = false;
        isRotating = false;
        Transform mainTransform = GameObject.Find("FermiVision Canvas").transform.Find("ViewMaster");
        Eye_L = mainTransform.Find("Eye_L").gameObject;
        Eye_R = mainTransform.Find("Eye_R").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
            Rotate();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscape();
        }
        if (LerpFlag)
        {
            Vector3 RPos = Eye_R.GetComponent<RectTransform>().localPosition;
            RPos.x  = Mathf.Lerp(0.0f, 25.0f, Time.deltaTime * 0.7f) *Mathf.PerlinNoise(0.0f, 1.2f);
            Eye_R.GetComponent<RectTransform>().localPosition = RPos;

            Vector3 LPos = Eye_L.GetComponent<RectTransform>().localPosition;
            LPos.x = Mathf.Lerp(0.0f, -25.0f, Time.deltaTime * 0.7f) * Mathf.PerlinNoise(0.0f, 1.2f);
            Eye_L.GetComponent<RectTransform>().localPosition = LPos;
        }
        else
        {
            Vector3 RPos = Eye_R.GetComponent<RectTransform>().localPosition;
            RPos.x = 25.0f;
            Eye_R.GetComponent<RectTransform>().localPosition = RPos;

            Vector3 LPos = Eye_L.GetComponent<RectTransform>().localPosition;
            LPos.x = -25.0f;
            Eye_L.GetComponent<RectTransform>().localPosition = LPos;
        }
        Camera.main.transform.LookAt(this.transform);
    }

    void OnMouseEnter()
    {
        CanRotate = true;
    }

    void OnMouseExit()
    {
        CanRotate = false;
    }
    void OnMouseDown()
    {
        if (CanRotate)
            isRotating = true;
    }
    void OnMouseUp()
    {
        CanRotate = false;
        isRotating = false;
    }
    void Rotate()
    {
        Debug.Log("ROTATING");
        //Rotate Object along mouse direction
        float _x = Input.GetAxis("Mouse X");
        float _y = Input.GetAxis("Mouse Y");
        this.transform.rotation = Quaternion.Euler(new Vector3(_x,_y,0.0f));
    }

    void OnEscape() {
        LerpFlag = false;
        Player.GetComponent<RigidbodyFirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        obj = Instantiate(EquipPrefab, SpawnPoint.transform.position, Quaternion.Euler(0, 0, 60));
        obj.transform.parent = SpawnPoint.transform;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 60.0f);
        obj.transform.localScale *= 0.2f;
        Destroy(this.gameObject);
    }
}
