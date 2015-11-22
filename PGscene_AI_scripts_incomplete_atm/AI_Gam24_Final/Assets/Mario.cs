﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mario : AI_Main 
{
    public int damage = 25;
    public bool jumping;
    

	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			print ("Dead");
			self.GetComponent<AI_Main>().KnockBack(600);
		}
	}
	public void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Target")
		{
			self.GetComponent<Mario>().TakeDamage(damage);
            other.gameObject.GetComponent<AI_Main>().KnockBack(300);
		}
	}
   
    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CanJump")
        {
            jumping = true;
            if (jumping == true)
            {
                self.layer = LayerMask.NameToLayer("Phasing");
                self.GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
                jumping = false; 
                StartCoroutine(Timer(2));
            }            
        }
    }
    IEnumerator Timer (float timer)
    {
        yield return new WaitForSeconds(timer);
        self.layer = LayerMask.NameToLayer("Default");

    }*/
}