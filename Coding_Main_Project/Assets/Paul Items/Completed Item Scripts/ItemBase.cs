using UnityEngine;
using System.Collections;

public class ItemBase : MonoBehaviour 
{
	public virtual void Start()
	{

	}

	public virtual void Update()
	{

	}
	public virtual void SmashUse()
	{


	}
	public virtual void Consume ()
	{
		print ("Consume base class");
	}
	
	public virtual void Use ()
	{
		print ("Use base class");
	}

	public virtual void StopUse()
	{
		print ("StopUse base class");
	}

	public virtual void SmashUse ()
	{
		print ("SmashUse base class");
	}

	public virtual void OnHit ()
	{
		print ("OnHit base class");
	}
}
