using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour
{
    BaseAbility basic;
    //public float horizontalSpeed = 2.0f;
    //public float verticalSpeed = 2.0f;
    //public float speed = 10f;
    public GameObject fire;
    public GameObject eFire;
    public float delayTime;
    public float delay = 2f;
    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*float h = horizontalSpeed * Input.GetAxis("Left Trigger");
        self.GetComponent<Rigidbody>().AddForce(Vector3.forward * h * speed);
        float v = verticalSpeed * Input.GetAxis("Right Trigger");
        self.GetComponent<Rigidbody>().AddForce(Vector3.forward * h * speed);*/
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            if(Time.time >= delayTime)
            {
                Instantiate(fire, transform.position, transform.rotation);
                delayTime = Time.time + delay;
                
            }
        }    
    }
}
