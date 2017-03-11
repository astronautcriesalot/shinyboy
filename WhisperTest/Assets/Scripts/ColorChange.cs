using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

	public Color colorStart;
	public Color colorEnd;
	public Renderer rend;
	public float amp;
	public float duration = 1.0F;

	Color pink = new Color32(251,57,154,255);
	Color orange = new Color32(253,166,124,255);
	Color yellow = new Color32(253,230,164,255);
	Color green = new Color32(190,226,180,255);
	Color blue = new Color32(94,212,247,255);
	Color indigo = new Color32(76,153,248,255);
	Color violet = new Color32(152,97,250,255);
	Color black = new Color32(0,0,0, 255);
	Color white = new Color32(255,255,255,255);

	public Color lerpedColor;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		amp = GetComponent<SourceAmplitude> ().myVolume;
	}

	// Update is called once per frame
	void Update () {
		lerpedColor = Color.Lerp(Color.white, Color.black, (amp * 3));
		rend.material.color = lerpedColor;
		print (lerpedColor);
	}
}
