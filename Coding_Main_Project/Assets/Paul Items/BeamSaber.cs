using UnityEngine;
using System.Collections;

public class BeamSaber : ItemBase
{

	public float damage = 17.0f;
	public float baseKnockBack = 22.0f;

	public override void SmashUse()
	{
		damage = 50.0f;
		baseKnockBack = 47.0f;

	}
	public override void Use()
	{
		damage = 17.0f;
		baseKnockBack = 22.0f;
	}
}
