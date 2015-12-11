using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
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
    public float counter = 0;
    public GameObject spawner;
    public GameObject fist1;
    public GameObject fist2;
    public GameObject fist3;
    public GameObject fist4;
    public GameObject face1;
    public GameObject face2;
    public GameObject face3;
    public GameObject face4;
    
       
    // Use this for initialization
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
        CounterCheck();
	}

    

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fist1.SetActive(true);
            fist2.SetActive(true);
            fist3.SetActive(true);
            fist4.SetActive(true);
            
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            fist1.SetActive(false);
            fist2.SetActive(false);
            fist3.SetActive(false);
            fist4.SetActive(false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            rigidbody.velocity = new Vector3(-move, 0, 0);
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
            transform.rotation = Quaternion.Euler(0, 90, 0);
            rigidbody.velocity = new Vector3(move,0, 0);
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
            player.layer = LayerMask.NameToLayer("Phasing");
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
            canJump = false;
            hasJumped = true;
            player.GetComponent<Rigidbody>().AddForce(Vector3.down * forceDown);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            player.layer = LayerMask.NameToLayer("Player");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W) && hasJumped == true)
            {
                player.layer = LayerMask.NameToLayer("Phasing");
                player.GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
                    hasJumped = false;
                player.GetComponent<Rigidbody>().AddForce(Vector3.down * forceDown);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                player.layer = LayerMask.NameToLayer("Player");
            }
        }
        
        if(Input.GetKey (KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector3(move*2, 0, 0);
        }
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(-move * 2, 0, 0);
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
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Side")
        {
            transform.Translate(0, 10, 0);
        }
        if (other.gameObject.tag == "Boundary")
        {
            rigidbody.velocity = Vector3.zero;
            this.gameObject.GetComponent<BaseAbility>().health = 10;
            this.gameObject.GetComponent<BaseAbility>().baseKB = 10;
            player.gameObject.transform.position = spawner.transform.position;
            counter++;
        }
        if (counter >= 4)
        {
            Destroy(player);
        }
    }
    void CounterCheck()
    {
        if (counter == 1)
        {
            print("1");
            face1.SetActive(false);
        }
        if (counter == 2)
        {
            face2.SetActive(false);
        }
        if (counter == 3)
        {
            face3.SetActive(false);
        }
        if (counter == 4)
        {
            face4.SetActive(false);
        }
    }
    public void KnockBack(float value)
    {
        Vector3 direction = transform.InverseTransformDirection(0, 1, 1);
        this.GetComponent<Rigidbody>().AddForce(direction * value);
    }
}
