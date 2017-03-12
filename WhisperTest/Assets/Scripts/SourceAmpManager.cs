using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceAmpManager : MonoBehaviour {
    SourceAmplitude[] allSourceAmps;
    List<SourceAmplitude> deadZoneAmps;
    List<SourceAmplitude> clearZoneAmps;
    List<SourceAmplitude> fuzzZoneAmps;

    [SerializeField] float fuzzUpperLimit;
    [SerializeField] float fuzzLowerLimit;
    [SerializeField] float clearUpperLimit;
    [SerializeField] float clearLowerLimit;


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
        SortAllAmps();

        // processes all amps
        DoStuffToDeadAmps();
        DoStuffToFuzzAmps();
        DoStuffToClearAmps();

	}

    void DoStuffToDeadAmps()
    {
        foreach (SourceAmplitude amp in deadZoneAmps)
        {
            
        }
        
    }

    void DoStuffToFuzzAmps()
    {
        foreach (SourceAmplitude amp in fuzzZoneAmps)
        {
            // add your code in here
        }

    }

    void DoStuffToClearAmps()
    {
        foreach (SourceAmplitude amp in clearZoneAmps)
        {
            // add your code in here
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
            //less than upper limit, more than lower limit, add to corresponding list
            if (vol <= clearUpperLimit && vol >= clearLowerLimit) clearZoneAmps.Add(amp);
            else if (vol <= fuzzUpperLimit && vol >= fuzzLowerLimit) fuzzZoneAmps.Add(amp);
            else deadZoneAmps.Add(amp);
        }
    }

}
