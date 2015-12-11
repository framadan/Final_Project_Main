using UnityEngine;
using System.Collections;

public class CameraTrigger1 : MonoBehaviour
{

    public float distanceOne, distanceValueOne;

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            distanceOne = distanceOne + distanceValueOne;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            distanceOne = distanceOne - distanceValueOne;
        }
    }

}
