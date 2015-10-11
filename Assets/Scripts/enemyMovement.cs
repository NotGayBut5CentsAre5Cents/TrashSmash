using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

    public Vector2 velocity = new Vector2(-400, 0);
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().AddForce(velocity);
	
	}
}
