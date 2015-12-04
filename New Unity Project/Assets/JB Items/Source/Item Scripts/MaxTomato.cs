using UnityEngine;
using System.Collections;

public class MaxTomato : MonoBehaviour 
{
	public float healAmount = 0.0f;

	public AudioClip eatFood = null;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void GetHealed(ItemUser weilder)
	{
		weilder.GetBuffed (null, eatFood, 0, healAmount, 1);
	}

}
