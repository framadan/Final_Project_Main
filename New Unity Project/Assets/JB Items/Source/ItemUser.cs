﻿using UnityEngine;
using System.Collections;

public class ItemUser : MonoBehaviour 
{
	public Items item = Items.None;

	public float grabRadius = 1f;

	Collider[] hitArray;

	void Start ()
	{
		item = Items.None;
	}

	void Update () 
	{
		if (Input.GetButtonDown("")) //Input
		{
			// Item Distance Check via Overlap Sphere.
			DistanceCheck ();
			Grab ();
		}
	}

	void DistanceCheck ()
	{
		hitArray = Physics.OverlapSphere(gameObject.transform.position, grabRadius);
	}

	void Grab ()
	{
		foreach (Collider hit in hitArray)
		{				
			if (hit.gameObject.GetComponent<Item>() != null) // This object is an Item.  
			{
				if (item == Items.None) // My hands are free.
				{
					// Run the Pick up animation.
					// Play pick up sound. 
					hit.gameObject.GetComponent<Item>().GetGrabbed(gameObject);
				}
			}
		}
	}

	public void GetBuffed (Material material = null, AudioClip audioClip = null, float duration = 0, float damageMod = 0, float gravityMod = 1f)
	{
		if(audioClip != null)
			AudioSource.PlayClipAtPoint (audioClip, gameObject.transform.position);
		if(material != null)
			gameObject.GetComponent<MeshRenderer> ().material = material;
	}

	public IEnumerator Duration (float duration)
	{
		yield return new WaitForSeconds(duration);

		//gameObject.GetComponent<>().ResetValues;
	}
}


/*
 *	 
 */