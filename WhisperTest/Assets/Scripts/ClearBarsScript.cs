using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBarsScript : MonoBehaviour {

    public GameObject GUL, CUL, GLL, CLL, ampManager;
    private float upperPos, lowerPos, lockedY;
    private SourceAmpManager sam;

	// Use this for initialization
	void Start ()
    {
        upperPos = GUL.GetComponent<RectTransform>().anchoredPosition.x;
        lockedY = GUL.GetComponent<RectTransform>().anchoredPosition.y;
        lowerPos = GLL.GetComponent<RectTransform>().anchoredPosition.x;
        sam = ampManager.GetComponent<SourceAmpManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float newUpperPos = Mathf.Lerp(lowerPos, upperPos, (sam.getClearUpperLimit() - sam.globalLowerLimit) / (sam.globalUpperLimit - sam.globalLowerLimit));
        CUL.GetComponent<RectTransform>().anchoredPosition = new Vector3(newUpperPos, lockedY, 0);
        float newLowerPos = Mathf.Lerp(lowerPos, upperPos, (sam.getClearLowerLimit() - sam.globalLowerLimit) / (sam.globalUpperLimit - sam.globalLowerLimit));
        CLL.GetComponent<RectTransform>().anchoredPosition = new Vector3(newLowerPos, lockedY, 0);
    }
}
