using UnityEngine;
using System.Collections;

public class HomeRunBat : ItemBase 
{

	public float baseKnockBack = 20.0f;
	public float damage = 15.0f;

	override void SmashUse() 
	{
		baseKnockBack = 9000.0f;
		damage = 9000.0f;
	}
	override void Use()
	{
		baseKnockBack = 20.0f;
		damage = 15.0f;
	}
}
