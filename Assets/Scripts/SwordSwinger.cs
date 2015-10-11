using UnityEngine;
using System.Collections;

public class SwordSwinger : MonoBehaviour {

    public float tiltAngle = -45F;
    public float smooth = 0.5F;
    public bool canSwing = true;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetMouseButtonDown(0) && canSwing)
        {
            StartCoroutine("Rotate", tiltAngle);
        }
	
	}

    private IEnumerator Rotate(float to)
    {
        GameObject go = GameObject.Find("Gps");
        GPS gps = go.GetComponent<GPS>();
        canSwing = false;
        for (double i = -to; i >= to; i -= gps.sum/100 + 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, (int)i);
            yield return null;
        }

        for (double i = to; i <= -to; i += gps.sum/100 + 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, (int)i);
            yield return null;
        }
        canSwing = true;
        yield break;

    }


}
