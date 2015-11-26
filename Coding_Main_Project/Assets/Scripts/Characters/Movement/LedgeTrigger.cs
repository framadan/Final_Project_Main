using UnityEngine;
using System.Collections;

public class LedgeTrigger : MonoBehaviour
{
    public bool playerCollisionDetection = false;

	// Use this for initialization
	void Start () 
	{
        //GameObject player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void OnTriggerStay(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            playerCollisionDetection = true;
        }

        if (playerCollisionDetection == true)
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.PlayerFallSpeedDecrease();
            other.transform.position = new Vector3(other.transform.position.x, gameObject.transform.position.y, other.transform.position.z);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.PlayerFallSpeedIncrease();
            Debug.Log("Player has left the trigger!");
            playerCollisionDetection = false;
       }
    }
}