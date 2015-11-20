using UnityEngine;
using System.Collections;

public class MetalBox : MonoBehaviour 
{
	public Material metalMario = null;

	public float duration = 20f;
	public float gravityMod = 1.75f;
	public float damageMod = 0.7f;
	
	public AudioClip metalStep = null;

	public void DoTheDo (ItemUser weilder)
	{
		weilder.GetBuffed (metalMario, metalStep, duration, damageMod, gravityMod);
	}
}
