using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public Renderer rend;
    public float duration = 1.0F;

    Color pink = new Color32(251, 57, 154, 255);
    Color orange = new Color32(253, 166, 124, 255);
    Color yellow = new Color32(253, 230, 164, 255);
    Color green = new Color32(190, 226, 180, 255);
    Color blue = new Color32(94, 212, 247, 255);
    Color indigo = new Color32(76, 153, 248, 255);
    Color violet = new Color32(152, 97, 250, 255);
    public Color[] colorMarkers;

    private List<float> ampHistory = new List<float>();
    private int HISTORY_LENGTH = 48;
    public float min_AMP = 0f;
    public float max_AMP = 0.01f;

    /*private float TIME_DELAY = 0.1f;
    private float progress = 0.0f;
    private bool shouldCalculate = true;
    private Color colorStart = Color.white;
    private Color colorEnd = Color.white;*/

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (colorMarkers.Length == 0)
        {
            colorMarkers = new Color[7];
            //colorMarkers[0] = pink;
            //colorMarkers[1] = orange;
            //colorMarkers[2] = yellow;
            //colorMarkers[3] = green;
            //colorMarkers[4] = blue;
            //colorMarkers[5] = indigo;
            //colorMarkers[6] = violet;

            colorMarkers[0] = violet;
            colorMarkers[1] = indigo;
            colorMarkers[2] = blue;
            colorMarkers[3] = green;
            colorMarkers[4] = yellow;
            colorMarkers[5] = orange;
            colorMarkers[6] = pink;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (shouldCalculate)
        {
            colorStart = colorEnd;
            colorEnd = calcNewColor();
            shouldCalculate = false;
        }
        else if (progress > TIME_DELAY)
        {
            progress -= TIME_DELAY;
            shouldCalculate = true;
        }
        progress += Time.deltaTime;
        rend.material.color = Color.Lerp(colorStart, colorEnd, Mathf.Clamp(progress / TIME_DELAY, 0, 1));*/
        rend.material.color = calcNewColor();
    }

    Color calcNewColor()
    {
        float amp = Mathf.Lerp(0, 1, (GetComponent<SourceAmplitude>().myVolume - min_AMP) / (max_AMP - min_AMP));
        ampHistory.Add(amp);
        if (ampHistory.Count > HISTORY_LENGTH)
            ampHistory.RemoveAt(0);
        float averageAmp = 0;
        foreach (float a in ampHistory)
        {
            averageAmp += a;
        }
        averageAmp = averageAmp / ampHistory.Count;
        int index = (int)Mathf.Floor(averageAmp * colorMarkers.Length);
        if (index >= colorMarkers.Length - 1) return colorMarkers[colorMarkers.Length - 1];
        float t = Mathf.Clamp01(averageAmp * colorMarkers.Length - index);
        return Color.Lerp(colorMarkers[index], colorMarkers[index + 1], t);
    }
}

