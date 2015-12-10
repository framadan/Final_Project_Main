using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mario : AI_Main_02
{
    public float counter = 0;
    public GameObject spawner;
    public bool hit1 = true;
    public bool hit2;
    public bool hit3;

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
            transform.Translate(0, 10, 0);
        }
    }

    /*public virtual void AnimAttack()
    {
        if(Vector3.Distance(gameObject.transform.position, currentTarget.transform.position) <= 50)
        {
            if(hit1 == true)
            {
                print("1");
                gameObject.GetComponent<Animation>().Play("mario_backflip");
                hit1 = false;
                hit2 = true;
                print("2");
            }
            else if (hit2 == true)
            {
                gameObject.GetComponent<Animation>().PlayQueued("mario_punch_up");
                hit2 = false;
                hit3 = true;
            }
            else if(hit3 == true)
            {
                gameObject.GetComponent<Animation>().PlayQueued("mario_charge_punch");
                hit3 = false;
                hit1 = true;
            }
        }
    }*/
}
