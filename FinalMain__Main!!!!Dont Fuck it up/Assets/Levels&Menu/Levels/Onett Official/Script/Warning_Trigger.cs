using UnityEngine;
using System.Collections;

public class Warning_Trigger : MonoBehaviour 
{

	public GameObject Warning;
	// Use this for initialization
	void Start () 
	{
		Warning.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 

	{
		
	}
	public void OnTriggerEnter(Collider other)

	{
		if (other.gameObject.tag == "Car")
		{
			//print ("Warning"); 
			Warning.SetActive (true);
		}
	}
	public void OnTriggerExit(Collider other)
		
	{
		if (other.gameObject.tag == "Car")
		{
			//print ("Warning"); 
			Warning.SetActive (false);
		}
	}

}
