using UnityEngine;
using System.Collections;

public class LedgeTrigger : MonoBehaviour
{


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Debug.Log ("ASdgkjashdfkh");
		}
	}

}