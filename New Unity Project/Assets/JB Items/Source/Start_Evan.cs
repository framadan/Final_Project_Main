using UnityEngine;
using System.Collections;

public class Start_Evan : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		GameObject t = new GameObject ("Tomato");
		t.AddComponent<Tomato_Evan> ();

		t.GetComponent<Item_Evan> ().Consume ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
