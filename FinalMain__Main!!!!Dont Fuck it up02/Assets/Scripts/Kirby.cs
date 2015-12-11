using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Kirby : AI_Main_02
{
    public int damage = 25;
    public bool jumping;
    public float counter = 0;
    public GameObject spawner;
    public GameObject kirby1;
    public GameObject kirby2;
    public GameObject kirby3;
    public GameObject kirby4;


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
        
        if (other.gameObject.tag == "Side")
        {
            transform.Translate(0, 10, 0);
        }
    }
    public virtual void LateUpdate()
    {
        CounterCheck();
    }
    void CounterCheck()
    {
        if (counter == 1)
        {
            kirby1.SetActive(false);
        }
        if (counter == 2)
        {
            kirby2.SetActive(false);
        }
        if (counter == 3)
        {
            kirby3.SetActive(false);
        }
        if (counter == 4)
        {
            kirby4.SetActive(false);
            Destroy(self);
        }
    }
}

