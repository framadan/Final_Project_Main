using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BaseAbility : MonoBehaviour 
{
	public float p;
	public float d;
	public float w;
	public float s;
	public float b;
	public float r;
	public float formula;

	// Use this for initialization
	void Start () 
	{
		formula = (((((p / 10f + p * d / 20f) * w * 1.4f) + 18f) * s) + b) * r;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public virtual void KnockBack(float value)
	{
		float num = (((((p / 10f + p * value / 20f) * w * 1.4f) + 18f) * s) + b) * r;
		Vector3 direction = transform.InverseTransformDirection (0, 1, 1);
		this.gameObject.GetComponent<Rigidbody> ().AddForce (direction * num);
	}
	public virtual void TakeDamage(float damage)
	{
		p = 1f;
		p += d;
		if (p >= 50f) 
		{

		}
	}
	public virtual void Weight(float weight)
	{

	}
}

//Links
//http://www.ssbwiki.com/knockback
//http://www.ssbwiki.com/Kirby_(SSBB)
//
