﻿using UnityEngine;
using System.Collections;

public class deathZone : MonoBehaviour
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Char")
		{
			print("destroy");
			Destroy(other.gameObject);
		}
	}
}
