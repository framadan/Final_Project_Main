using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour 
{
	public float speed = 20.0f;
    public float timer = 0.0f;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        timer = timer + Time.deltaTime;
        if (timer < 100)
        {
            speed = 20;
        }
        if (timer > 100)
        {
            speed = -20;
        }
        if (timer >= 200)
        {
            timer = 0;
        }
		gameObject.transform.Translate (Vector3.right * speed * Time.deltaTime);
        //print(speed);
       
	}
   
}
