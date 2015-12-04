using UnityEngine;
using System.Collections;

public class Hammer : ItemBase
{
	public float damage = 125.0f;
	public float baseKnockBack = 90.0f;


	public override void Use()
	{
		damage = 125.0f;
		baseKnockBack = 90.0f;
		//Damage must be continues while the effect lasts, make timer 8 seconds.
	}
}
