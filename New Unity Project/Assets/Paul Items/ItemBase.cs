using UnityEngine;
using System.Collections;

public class ItemBase : MonoBehaviour 
{

	public virtual void Consume ()
	{
		print ("base class");
	}
	
	public void Use ()
	{
		
	}
}
