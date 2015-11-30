using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sonic : AI_Main_02
{
    public int damage = 25;
    public bool jumping;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            print("Dead");
            self.GetComponent<AI_Main_02>().KnockBack(600);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            self.GetComponent<Sonic>().TakeDamage(damage);
            self.gameObject.GetComponent<AI_Main_02>().KnockBack(200);
        }
    }
}
