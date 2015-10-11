using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GPSText : MonoBehaviour
{

    Text instruction;

    void Start()
    {
        instruction = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("Gps");
        GPS gps = go.GetComponent<GPS>();
        instruction.fontSize = 30;
        instruction.text = "Meters ran: " + gps.sum;
    } 
}
