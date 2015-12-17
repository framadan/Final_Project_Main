using UnityEngine;
using System.Collections;

public class StarRod : ItemBase 
{

	public float damage = 17.0f;
	public float baseKnockBack = 22.0f;

	public int ammo = 18;
	private int ammoCost = 1;

	public GameObject StarShot = null;
	
	public override void SmashUse()
	{
		damage = 50.0f;
		baseKnockBack = 47.0f;

		if (ammo > 0) 
		{
			Instantiate (StarShot, transform.position, transform.rotation);
			ammo -= ammoCost;
		}
		
	}
	public override void Use()
	{
		damage = 17.0f;
		baseKnockBack = 22.0f;
	}
}
