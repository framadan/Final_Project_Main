using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mario : AI_Main 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
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
			other.gameObject.GetComponent<>().TakeDamage(damage);
		}
	}
}
