using UnityEngine;
using System.Collections;

public class Test2 : Test 
{

	public Test2(int newInt ,int someInt = 1,int otherInt = 1, string someString = "")
	{
		this.newInt = newInt;
		base.Initailize (someInt, otherInt, someString);
	}
	int newInt = 0;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
