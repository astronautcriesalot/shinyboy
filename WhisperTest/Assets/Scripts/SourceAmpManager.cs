using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceAmpManager : MonoBehaviour {
    SourceAmplitude[] allSourceAmps;
    List<SourceAmplitude> deadZoneAmps;
    List<SourceAmplitude> clearZoneAmps;
    List<SourceAmplitude> fuzzZoneAmps;

	[SerializeField] float distortLowerLimit;
	[SerializeField] float distortUpperLimit;
    [SerializeField] float fuzzUpperLimit;
    [SerializeField] float fuzzLowerLimit;
    [SerializeField] float clearUpperLimit;
    [SerializeField] float clearLowerLimit;

	public float globalUpperLimit;
	public float globalLowerLimit;

	public float clearRangeSize = 0.1f;
	public float fuzzRangeSize = 0.15f;
	public float currentCenter = 0.5f;

	public KeyCode scrubUp = KeyCode.UpArrow;
	public KeyCode scrubDown = KeyCode.DownArrow;

	public float scrubSensitivity = 1f; 

	float combinedClearAmps= 0;
	float combinedFuzzAmps= 0;

	public float totalAmps = 0;


    void Awake()
    {
        deadZoneAmps = new List<SourceAmplitude>();
        clearZoneAmps = new List<SourceAmplitude>();
        fuzzZoneAmps = new List<SourceAmplitude>();
    }
	void Start () {
        allSourceAmps = FindObjectsOfType<SourceAmplitude>();
	}
	
	// Update is called once per frame
	void Update () {

        // sorts all amps in the scene into dead, clear and fuzz lists
        resetAmpArrays();

		handleInput ();

		getCurrentMaxMinFuzz ();
		getCurrentMaxMinClear ();

        SortAllAmps();

        // processes all amps
        DoStuffToDeadAmps();
        DoStuffToFuzzAmps();
        DoStuffToClearAmps();

		totalAmps = combinedFuzzAmps + combinedClearAmps;

	}

    void DoStuffToDeadAmps()
    {
        foreach (SourceAmplitude amp in deadZoneAmps)
        {
			amp.gameObject.GetComponent<AudioSource> ().mute = true;
        }
        
    }

    void DoStuffToFuzzAmps()
    {
		combinedFuzzAmps = 0;
        foreach (SourceAmplitude amp in fuzzZoneAmps)
        {
			amp.gameObject.GetComponent<AudioSource> ().mute = false;
			amp.enableFuzz ();
			combinedFuzzAmps += amp.myVolume;
        }

    }

    void DoStuffToClearAmps()
	{
		combinedClearAmps = 0;
        foreach (SourceAmplitude amp in clearZoneAmps)
        {
			amp.gameObject.GetComponent<AudioSource> ().mute = false;
			amp.disableFuzz();
			combinedClearAmps += amp.myVolume;
        }

    }


    /// <summary>
    ///  just clears all amp lists
    /// </summary>
    void resetAmpArrays()
    {
        deadZoneAmps.Clear();
        fuzzZoneAmps.Clear();
        clearZoneAmps.Clear();
    }


    /// <summary> 
    /// sort source amplitudes into either dead zone
    /// fuzz zone, or clear zone based on the variable
    /// myVolume in SourceAmplitude
    /// </summary>
    void SortAllAmps()
    {
        foreach(SourceAmplitude amp in allSourceAmps)
        {
            float vol = amp.myVolume;
			//print (amp.myVolume);
            //less than upper limit, more than lower limit, add to corresponding list
			if (vol <= clearUpperLimit && vol >= clearLowerLimit) {clearZoneAmps.Add(amp);}
           	else if (vol <= fuzzUpperLimit && vol >= fuzzLowerLimit) fuzzZoneAmps.Add(amp);
			else {deadZoneAmps.Add(amp);}
        }
    }

	void getCurrentMaxMinClear()
	{
		clearUpperLimit = Mathf.Clamp (currentCenter + (0.5f * clearRangeSize), globalLowerLimit, globalUpperLimit);
		clearLowerLimit = Mathf.Clamp (currentCenter - (0.5f * clearRangeSize),globalLowerLimit, globalUpperLimit);
	}

	void getCurrentMaxMinFuzz()
	{
		fuzzUpperLimit = Mathf.Clamp (currentCenter /*+ (0.5f * fuzzRangeSize)*/, globalLowerLimit, globalUpperLimit);
		fuzzLowerLimit = Mathf.Clamp (currentCenter - (0.5f * fuzzRangeSize),globalLowerLimit, globalUpperLimit);
	}

	void handleInput()
	{
		if (Input.GetKey (scrubUp)) {
			currentCenter = Mathf.Clamp (currentCenter + (Time.deltaTime * scrubSensitivity), globalLowerLimit + (0.5f * clearRangeSize), globalUpperLimit - (0.5f * clearRangeSize));
		}
		if (Input.GetKey (scrubDown)) {
			currentCenter = Mathf.Clamp (currentCenter - (Time.deltaTime * scrubSensitivity), globalLowerLimit + (0.5f * clearRangeSize), globalUpperLimit - (0.5f * clearRangeSize));
		}
	}

    public float getClearUpperLimit()
    {
        return clearUpperLimit;
    }

    public float getClearLowerLimit()
    {
        return clearLowerLimit;
    }
}
