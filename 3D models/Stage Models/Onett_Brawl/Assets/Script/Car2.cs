using UnityEngine;
using System.Collections;

public class Car2 : MonoBehaviour 
{
	public float speed = 2.0f;
	
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame	
	void Update () 
	{
		transform.Translate (Vector3.left * Time.deltaTime * speed);
	}
	void OnCollisionEnter (Collision other)
	{
	}
}

