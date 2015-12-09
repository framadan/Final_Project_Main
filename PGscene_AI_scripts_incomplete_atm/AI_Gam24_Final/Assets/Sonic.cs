using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sonic : AI_Main_02
{
    public int damage = 25;
    public bool jumping;
    public float counter = 0;
    public GameObject spawner;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            rigidbody.velocity = Vector3.zero;
            this.gameObject.GetComponent<BaseAbility>().health = 10;
            this.gameObject.GetComponent<BaseAbility>().baseKB = 10;
            this.gameObject.transform.position = spawner.transform.position;
            counter++;
        }
        if (counter >= 4)
        {
            Destroy(self);
        }
        if (other.gameObject.tag == "Side")
        {
            transform.Translate(0, 2, 0);
        }
    }
}
