using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;



public class Test : MonoBehaviour 
{


	public Test(int someInt = 1, int otherInt = 1 , string someString = "")
	{
		this.Initailize (someInt, otherInt, someString);
	}

	public void Initailize(int someInt = 1, int otherInt = 1 , string someString = "")
	{
		this.someInt = someInt;
		this.otherInt = otherInt;
		this.someString = someString;
	}

	public int someInt = 0;
	public int otherInt = 0;
	public string someString = "";

	// Use this for initialization
	void Start ()
	{
		Vector3 newww = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
