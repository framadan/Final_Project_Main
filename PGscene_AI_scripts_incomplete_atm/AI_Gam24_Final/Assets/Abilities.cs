using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Abilities : MonoBehaviour 
{
	public float knockBack01 = 100f;
	public float knockBack02 = 150f;
	public float knockBack03 = 200f;

	public float health = 1.0f;
	public float damage = 5.0f;
	public float weight = 1.0f;
	public float nockBack = 1.0f;
	public float baseKnockback = 1.0f;
	public float r = 1.0f;
	public float delay;
	public float delayTime = 2.0f;
	public float num5 = 0.0f;
	public float damage01 = 25f;
	public float counter = 0;
	public bool hit = true;
	public bool hit2 = false;
	public bool hit3 = false;
	public GameObject equalTarget;
	// Use this for initialization
	void Start () 
	{
		//num1 = health / 10;
//		num2 = health * damage / 20;
//		num3 = num1 + num2;
//		num4 = weight * 1.4;
//		num5 = num3 *
		num5 = ((((((health / 10f + health * damage / 20f) * 
		           weight * 1.4f) + 18f) * nockBack) + baseKnockback) * r);
		Debug.Log (num5);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter(Collision other)
	{
		equalTarget = other.gameObject;
		if (other.gameObject.tag == "Player")
			//if(gameObject.GetComponent<PlayerMovement>() != null)
		{
			if (hit == true)
			{
				if(Vector3.Distance (other.gameObject.transform.position, this.transform.position) <= 2.0f)
				{

					other.gameObject.GetComponent<Abilities>().TakeDamage(damage);  
					//do increase damage bas
//					other.gameObject.GetComponent<Abilities> ().KnockBack (knockBack01);
//					other.gameObject.GetComponent<Abilities>().TakeDamage(damage);
					//will use GetComponent<Character/AI shared script> for the damage taking
					hit = false;
					hit2 = true;
				}
			}
			else if (hit2 == true)
			{
				if(Vector3.Distance (other.gameObject.transform.position, this.transform.position) <= 2.0f)
				{
					other.gameObject.GetComponent<Abilities> ().KnockBack (knockBack02);
					other.gameObject.GetComponent<Abilities>().TakeDamage(damage);

					hit2 = false;
					hit3 = true;
				}
			}
			else if(hit3 == true)
			{
				if(Vector3.Distance(other.gameObject.transform.position, this.transform.position) <= 2.0f)
				{
					other.gameObject.GetComponent<Abilities>().KnockBack(knockBack03);
					other.gameObject.GetComponent<Abilities>().TakeDamage(damage);

					hit3 = false;
					hit = true;
				}
			}
		}
	}
	public void TakeDamage(float _damage)
	{
		health += _damage;
		KnockBack (_damage);

//		if (health >= 50)
//		{
//			equalTarget.gameObject.GetComponent<Abilities> ().KnockBack (knockBack01 * 2);
//		} 

//		if (health >= 400) 
//		{
//			this.gameObject.GetComponent<Abilities>().KnockBack (1000);
//		}
	}
	public void WeightDown()
	{
		Vector3 direction = transform.InverseTransformDirection (0, -1, 0);
		this.GetComponent<Rigidbody> ().AddForce (direction * weight);
	}
	public void KnockBack(float value)
	{
		float num = ((((((health / 10f + health * value / 20f) *
		                weight * 1.4f) + 18f) * nockBack) + baseKnockback) * r);

		Vector3 direction = transform.InverseTransformDirection(0, 1, 1);
		this.GetComponent<Rigidbody>().AddForce(direction * num);
	}
}
