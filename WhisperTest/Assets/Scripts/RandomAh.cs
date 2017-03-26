using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAh : MonoBehaviour
{

    List<string> strs = new List<string>();
    public Text text;
    // Use this for initialization
    void Start()
    {
        text.text = "";

        int count = 0 ;
        string tempOut = "";
        while (count < 100)
        {
            count++;
            string curr = RandomizeAH();
            strs.Add(curr);
            tempOut += curr;
        }
        text.text = tempOut;
    }

    // Update is called once per frame
    void Update()
    {
        strs.Add(RandomizeAH());
        if (strs.Count > 100) strs.RemoveAt(0);

        string output="";
        foreach (string str in strs) output += str;

        text.text = output;
        
    }


    string RandomizeAH()
    {
        int numOfA = Random.Range(1, 15);
        int numOfH = Random.Range(3, 30);

        string output = "";
        for (int i = 0; i < numOfA; i++)
        {
            char c;
            c = (Random.Range(0, 2) == 0) ? c = 'a' : c = 'A';
            output += c;
        }
        for (int i = 0; i < numOfH; i++)
        {
            char c;
            c = (Random.Range(0, 2) == 0) ? c = 'h' : c = 'H';
            output += c;
        }
        print(output);
        return output;
    }
}
