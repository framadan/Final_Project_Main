using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using StateMachine;
using System.Linq;
using System;

public class CharacterBase : MonoBehaviour 
{
	//shield variables
	public float shieldTimer = 10f;
	public bool shieldOn = false;
	public bool shieldRecharge = true;
	public bool shieldBreak = false;
	public bool damageTaken = false;
	public float lowDamage = 0.5f;//just for now waiting for actual damage values
	public float medDamge = 1.5f;
	public float hihDamge = 2.5f;

	//player movement variables
	public float move;
	public float jump;
	public float delay = 2.0f;
	public float delayTime;
	public float forceDown;
	public bool canJump;
	public bool hasJumped;
	public GameObject player;
	Rigidbody rigidbody;
	public float fallSpeed;
	public Transform rotating;

	//wall jump variables
	public float Speed = 3f;
	public float GravityStrength = 5f;
	public float JumpSpeed = 10f;
	float verticalVelocity;
	Vector3 velocity;
	Vector3 groundedVelocity;
	Vector3 normal;
	bool WallJumping;

	public CharacterStateMachine stateMachine;


	// Use this for initialization
	void Start () 
	{
		stateMachine = gameObject.GetComponent<CharacterStateMachine> ();
		rigidbody = GetComponent<Rigidbody>();
		//learning state machine placement
		stateMachine.AddState (States.NO_FLINCH, 2, null, null , printEnd);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		Shielded();
		ShieldRecharge();
		ShieldBreak();
		Movement();
	}
	

	void Shielded()
	{
		if (Input.GetKey(KeyCode.LeftShift))//GetButtonDown will be used when we have a control scheme setup
		{
			//State where shield actions are on and unable to move, but able to Rdodge
			stateMachine.AddState (States.NO_DAMAGE);
			shieldOn = true;
			shieldRecharge = false;
			shieldTimer -=  Time.deltaTime ;
			
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			shieldOn = false;
			shieldRecharge = true;
		}
	}
	
	//this is just a quick thing to see if it works
//	void OnCollisionEnter(Collision col)
//	{
//		if (col.gameObject.name == "Cube")
//		{
//			damageTaken = true;
//			shieldTimer -= lowDamage;
//		}
//	}


	void ShieldRecharge()
	{
		if (shieldRecharge == true && shieldTimer < 10)
		{
			shieldTimer += Time.deltaTime;
		}
		if (shieldRecharge == true && shieldTimer == 10)
		{
			shieldRecharge = false;
		}
	}
	

	void ShieldBreak()
	{
		if (shieldTimer <= 0)
		{
			shieldBreak = true;
			stateMachine.RemoveState(States.NO_DAMAGE);
		}
		if (shieldBreak == true)
		{
			//states
		}
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
			player.layer = LayerMask.NameToLayer("Default");
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
			
			player.gameObject.GetComponent<PlayerMovement>().KnockBack(300);
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

	public void printStart(){Debug.Log ("start");}
	public void printUpdate(){Debug.Log ("update");}
	public void printEnd(){Debug.Log ("end");}
}


// The Wall jump Script?
//void Update()
//{
//Vector3 myVector = new Vector3(0,0,0);

//if (CharacterController.isGrounded)
//{
//	myVector.x = Imput.GetAxis("HOrizontal");
//	myVector.y = Input.GetAxis("Vertical");
//	myVector = Vector3.ClampMagnitude(myVector, 1f);
//	myVector = myVector * Speed * Time.deltaTime;

//}
//else
//{
//	myVector = groundedVelocity;
//	myVector*= Time.deltaTime;
//}
//myVector.y = verticalVelocity*Time.deltaTime;

//}
//void WallJumpCheck()
//{

//if(!isGrounded && ControllerColliderHit.tag == "Wall" && Input.GetKeyDown ("Jump"))
//{
//groundVelocity = Vector3.Reflect(groundedVelocity, normal);
//WallJumping()
//}
//else(!isGrounded && Input.GetKeyDown ("Jump"))
//{
//	Debug.Log("You're in the air!")
//}
//}
//void OnControllerColliderHit(ControllerColliderHit hit)
//{
//	normal = hit.normal;

//}
//}
