using UnityEngine;
using System.Collections;

public class CameraTrigger2 : MonoBehaviour
{

    public float distanceTwo, distanceValueTwo = 10.0f;

	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            distanceTwo = distanceTwo + distanceValueTwo;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            distanceTwo = distanceTwo - distanceValueTwo;
        }
    }
}
