using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerMovement_pg : MonoBehaviour
{
    
    public float move;
    public float jump;
    public float delay = 2.0f;
    public float delayTime;
    public float forceDown;
    public bool canJump;
    public bool hasJumped;
    public GameObject player;
    public Rigidbody rigidbody;
    public float fallSpeed;
    public Transform rotating;
    // Use this for initialization
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
	}

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            rigidbody.velocity = new Vector3(move, 0, 0);
            player.GetComponent<Rigidbody>().AddForce(Vector3.down * forceDown);
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                rigidbody.velocity = new Vector3(0, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            rigidbody.velocity = new Vector3(-move,0, 0);
            player.GetComponent<Rigidbody>().AddForce(Vector3.down * forceDown);
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                rigidbody.velocity = new Vector3(0, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.layer = LayerMask.NameToLayer("Phasing");
            player.GetComponent<Rigidbody>().AddForce(Vector3.down * forceDown);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            player.layer = LayerMask.NameToLayer("Player");
        }
        if (Input.GetKeyDown(KeyCode.W) && canJump == true)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
            canJump = false;
            hasJumped = true;
            player.GetComponent<Rigidbody>().AddForce(Vector3.down * forceDown);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W) && hasJumped == true)
            {   
                player.GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
                    hasJumped = false;
                player.GetComponent<Rigidbody>().AddForce(Vector3.down * forceDown);
            }
        }
        if(Input.GetKey (KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector3(-move*2, 0, 0);
        }
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(move * 2, 0, 0);
        }
    }

    public void PlayerFallSpeedDecrease()
    {
        fallSpeed = 0.0f;
    }

    public void PlayerFallSpeedIncrease()
    {
        fallSpeed = -25.0f;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            print("Touching");
            canJump = true;
        }
        if(other.gameObject.tag == "Player")
        {
            player.gameObject.GetComponent<PlayerMovement_pg>().KnockBack(600);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Side")
        {
            transform.Translate(0, 2, 0);
        }
    }
    public void KnockBack(float value)
    {
        Vector3 direction = transform.InverseTransformDirection(0, 1, 1);
        this.GetComponent<Rigidbody>().AddForce(direction * value);
    }
}
