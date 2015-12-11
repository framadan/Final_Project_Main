using UnityEngine;
using System.Collections;

public class Destroycars : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Car")
		{
			print("destroy");
			Destroy(other.gameObject);
		}
	}
}
