using UnityEngine;
using System.Collections;

public class StarMan : MonoBehaviour 
{
	public Material starMan = null;
	
	public float duration = 15f;

	public float damageMod = 0f;
	
	public AudioClip starMusic = null;

	public void DoTheDo (ItemUser weilder)
	{
		weilder.GetBuffed (starMan, starMusic, duration, damageMod);
	}
}
