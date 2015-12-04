﻿using UnityEngine;
using System.Collections;

public class RayGun : ItemBase 
{
	public GameObject projectile = null;
	public float coolDown = 0.0f;
	public AudioClip shotSound = null;
	public bool canFire = false;
	private float time = 0.0f;

	// Use this for initialization
	override void Start () 
	{
		time = coolDown;
	}
	
	// Update is called once per frame
	override void Update () 
	{
		if (time < coolDown)
			time += Time.deltaTime;
		if (time >= coolDown)
			canFire = true;
	}

	public override void Use()
	{
		if(canFire == true)
		{
			//play shotSound
			Instantiate (projectile, transform.position, transform.rotation);
			canFire = false;
			time = 0.0f;
		}

	}
}