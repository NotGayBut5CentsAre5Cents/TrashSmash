using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextVS : MonoBehaviour {

    Text instruction;

    void Start()
    {
        instruction = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        GameObject go = GameObject.Find("Hero");
        Dead dead = go.GetComponent<Dead>();
        if(dead.isDead)
        {
            instruction.fontSize = 30;
            instruction.text = "GAME OVER";
        }
	}
}
