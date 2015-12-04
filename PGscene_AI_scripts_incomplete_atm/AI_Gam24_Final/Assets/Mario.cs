using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mario : AI_Main_02
{
    public int damage = 25;
    public bool jumping;
    public float counter = 0;
    public GameObject spawner;


    public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			print ("Dead");
			self.GetComponent<AI_Main_02>().KnockBack(600);
		}
	}
//	public void OnCollisionEnter(Collision other)
//	{
//		if(other.gameObject.tag == "Player")
//		{
//            self.GetComponent<Mario>().TakeDamage(damage);
//            self.gameObject.GetComponent<AI_Main_02>().KnockBack(200);
//        }
//	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            self.gameObject.transform.position = spawner.transform.position;
            counter++;
        }
        if (counter >= 4)
        {
            Destroy(self);
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
