using UnityEngine;
using System.Collections;

public class HomeRunBat : ItemBase 
{

	float baseKnockBack = 20.0f;
	float damage = 15.0f;

	public override void SmashUse() 
	{
		baseKnockBack = 9000.0f;
		damage = 9000.0f;
	}
	public override void Use()
	{
		baseKnockBack = 20.0f;
		damage = 15.0f;
	}
}
