using UnityEngine;
using System.Collections;

public class Hammer : ItemBase
{
	public float damage = 125.0f;
	public float baseKnockBack = 90.0f;


	override void Use()
	{
		damage = 125.0f;
		baseKnockBack = 90.0f;


	}
}
