using UnityEngine;
using System.Collections;

public class FoodItem : ItemBase 
{
	public float healAmount = 0.0f; //Adjustable for different foods

	public AudioClip eatFood = null;


	public override void Consume()
	{
		//play audioclip
		//Restore health
	}

}
