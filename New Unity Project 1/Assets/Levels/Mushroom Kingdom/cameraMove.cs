﻿using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour 
{
	public float speed = 10.0f;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}
