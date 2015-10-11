using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dead : MonoBehaviour {
    public bool isDead = false;

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "DeadTrigger")
        {
            isDead = true;
            Time.timeScale = 0;
        }
    }
}
