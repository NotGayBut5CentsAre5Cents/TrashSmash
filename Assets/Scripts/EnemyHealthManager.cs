using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{
    public float health = 4;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (health<=0 )
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject go = GameObject.Find("Sword");
        SwordSwinger sword = go.GetComponent<SwordSwinger>();
        if (col.gameObject.tag == "Sword" && !sword.canSwing)
        {
            health -= 1;
        }
    }
}
