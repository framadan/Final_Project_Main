using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuSwitching : MonoBehaviour 
{
	public Canvas start;
	public Canvas charSelect;
	
	// Use this for initialization
	void Start ()
	{
		start.enabled = true;
		charSelect.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (start.enabled == true)
		{
			if(Input.GetMouseButton(0))
			{
				start.enabled = false;
				charSelect.enabled = true;
			}
		}

		if (charSelect.enabled == true) 
		{
			if(Input.GetKey (KeyCode.Backspace))
			{
				charSelect.enabled = false;
				start.enabled = true;
			}
		}
	}
}
