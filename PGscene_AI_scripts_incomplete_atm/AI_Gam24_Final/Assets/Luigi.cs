using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Luigi : AI_Main 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance(gameObject.transform.position, currentTarget.transform.position) <= 10.0f)
		{ 
			//Animation.Play("LightPunch");
		}
		if (Vector3.Distance (gameObject.transform.position, currentTarget.transform.position) <= 8.0f) 
		{
			//Animation.Play("HeavyPunch");
		}
		if (Vector3.Distance (gameObject.transform.position, currentTarget.transform.position) <= 12.0f) 
		{
			//Animation.Play("RangedAttack");
		}
		if (Vector3.Distance (gameObject.transform.position, currentTarget.transform.position) <= 5.0f) 
		{
			//Animation.Play("Block");
		}
	}
}
