using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;

    // Use this for initialization
    void Start()
    {
        float spawnSpeedE = 1.5f;
        InvokeRepeating("CreateEnimies", spawnSpeedE, spawnSpeedE);

        //InvokeRepeating ("CreateWeed", 20, 20);
    }

    void Update()
    {
        //GameObject go = GameObject.Find("Hero");
        //FappyBurdMovement dead = go.GetComponent<FappyBurdMovement>();
        //if (dead.isDead)
        //{
        //    CancelInvoke("CreatePupes");
        //}

    }
    void CreateEnimies()
    {
        Instantiate(enemy);
    }
}
