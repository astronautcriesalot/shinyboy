using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterScript : MonoBehaviour {

	public GameObject meterAmpManager;
	public float meterLevel;
	bool adjustMeterNow;

	GameObject meter1;
	GameObject meter2;
	GameObject meter3;
	GameObject meter4;
	GameObject meter5;
	GameObject meter6;

	float cap1 = 0.1f;
	float cap2 = 0.2f;
	float cap3 = 0.3f;
	float cap4 = 0.4f;

	// Use this for initialization
	void Start () {

		meterAmpManager = GameObject.Find ("AmpManager");

		meter1 = GameObject.Find ("Meter1");
		meter2 = GameObject.Find ("Meter2");
		meter3 = GameObject.Find ("Meter3");
		meter4 = GameObject.Find ("Meter4");
		meter5 = GameObject.Find ("Meter5");
		meter6 = GameObject.Find ("Meter6");

		meter1.gameObject.SetActive(false);
		meter2.gameObject.SetActive(false);
		meter3.gameObject.SetActive(false);
		meter4.gameObject.SetActive(false);
		meter5.gameObject.SetActive(false);
		meter6.gameObject.SetActive(false);	

		adjustMeterNow = true;
			
	}
	
	// Update is called once per frame
	void Update () {

		meterLevel = meterAmpManager.GetComponent<SourceAmpManager> ().totalAmps;
		if (adjustMeterNow) {
			StartCoroutine (MeterAdjust ());
		}

	}

	IEnumerator MeterAdjust()
	{
		adjustMeterNow = false;

		if (meterLevel <= 0f) 
		{
			meter1.gameObject.SetActive(false);
			meter2.gameObject.SetActive(false);
			meter3.gameObject.SetActive(false);
			meter4.gameObject.SetActive(false);
			meter5.gameObject.SetActive(false);
			meter6.gameObject.SetActive(false);	
		} 
		else if (meterLevel > 0f && meterLevel <= cap1)
		{
			meter1.gameObject.SetActive(true);
			meter2.gameObject.SetActive(false);
			meter3.gameObject.SetActive(false);
			meter4.gameObject.SetActive(false);
			meter5.gameObject.SetActive(false);
			meter6.gameObject.SetActive(false);	
		}
		else if (meterLevel > cap1 && meterLevel <= cap2)
		{
			meter1.gameObject.SetActive(true);
			meter2.gameObject.SetActive(true);
			meter3.gameObject.SetActive(false);
			meter4.gameObject.SetActive(false);
			meter5.gameObject.SetActive(false);
			meter6.gameObject.SetActive(false);	
		}	
		else if (meterLevel > cap2 && meterLevel <= cap3)
		{
			meter1.gameObject.SetActive(true);
			meter2.gameObject.SetActive(true);
			meter3.gameObject.SetActive(true);
			meter4.gameObject.SetActive(false);
			meter5.gameObject.SetActive(false);
			meter6.gameObject.SetActive(false);	
		}	
		else if (meterLevel > 0.01f && meterLevel <= 0.015f)
		{
			meter1.gameObject.SetActive(true);
			meter2.gameObject.SetActive(true);
			meter3.gameObject.SetActive(true);
			meter4.gameObject.SetActive(true);
			meter5.gameObject.SetActive(false);
			meter6.gameObject.SetActive(false);	
		}	
		else if (meterLevel > cap3 && meterLevel <= cap4)
		{
			meter1.gameObject.SetActive(true);
			meter2.gameObject.SetActive(true);
			meter3.gameObject.SetActive(true);
			meter4.gameObject.SetActive(true);
			meter5.gameObject.SetActive(true);
			meter6.gameObject.SetActive(false);	
		}
		else if (meterLevel > cap4)
		{
			meter1.gameObject.SetActive(true);
			meter2.gameObject.SetActive(true);
			meter3.gameObject.SetActive(true);
			meter4.gameObject.SetActive(true);
			meter5.gameObject.SetActive(true);
			meter6.gameObject.SetActive(true);		
		}

		//print(Time.time);
		yield return new WaitForSeconds(0.1f);
		adjustMeterNow = true;

	}
}
