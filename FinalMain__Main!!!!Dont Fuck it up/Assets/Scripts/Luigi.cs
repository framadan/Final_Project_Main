using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Luigi : AI_Main_02
{
    
    public bool jumping;
    public float counter = 0;
    public GameObject spawner;
    public GameObject luigi1;
    public GameObject luigi2;
    public GameObject luigi3;
    public GameObject luigi4;


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
            luigi1.SetActive(false);
        }
        if (counter == 2)
        {
            luigi2.SetActive(false);
        }
        if (counter == 3)
        {
            luigi3.SetActive(false);
        }
        if (counter >= 4)
        {
            luigi4.SetActive(false);
            Destroy(self);
        }
    }
}

