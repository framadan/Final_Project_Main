using UnityEngine;
using System.Collections;

public class MetalBox : ItemBase 
{
	public Material metalMario = null;

	public float duration = 20f;
	public float gravityMod = 1.75f;
	public float damageMod = 0.7f;

	public bool isMetal = false;
	
	public AudioClip metalStep = null;

	public override void Onhit () //if Metal Box is hit by player
	{
		isMetal = true;
	}

	IEnumerator WhileMetal()
	{
		while (isMetal) 
		{
		//pass values
		//yield return new WaitForSeconds (duration);
		}

		//I believe this is the basic idea we'll need
	}
}