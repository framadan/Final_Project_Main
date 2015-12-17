using UnityEngine;
using System.Collections;

public class SmashBall : ItemBase
{
	public float health = 40.0f;
	public bool canSmashMove = false;
	
	void OnCollisionOther ()
	{
		health = health - 10;
			if(health == 0)
			{
				canSmashMove = true;
			}
	}
}
