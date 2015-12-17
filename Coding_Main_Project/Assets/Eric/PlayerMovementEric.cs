using UnityEngine;
using System.Collections;

public class PlayerMovementEric : MonoBehaviour 
{
	//Player Movement
	public KeyCode left = KeyCode.LeftArrow;
	public KeyCode right = KeyCode.RightArrow;
	public KeyCode jump = KeyCode.UpArrow;
	public KeyCode crouch = KeyCode.DownArrow;

	public KeyCode grab = KeyCode.Q;
	public KeyCode shield = KeyCode.R;
	public KeyCode attack = KeyCode.S; //used for interaction with items
	public KeyCode special = KeyCode.A;

	public float movementSpeed = 0.0f;
	public float mouseSensitivity = 0.0f;
	public float jumpVelocity = 0.0f;
	public float jumpTime = 0.0f; //use to adjust when character should start falling
	
	public float upDownRotationLimit = 0.0f;
	float verticalVelocity = 0.0f;

	public Rigidbody rigidBody = null;

	public bool isGrounded = true;
	public bool isCrouching = false;
	public bool isJumping = false;

	public GameObject attackHitBox = null;
	public GameObject specialHitBox = null;
	public GameObject playerShield = null;
	public GameObject grabHitBox = null;

	public GameObject attackPosition = null;


	CharacterController characterController = null;

//	public bool IsGrounded
//	{
//		get{return characterController.isGrounded;}
//	}

	// Use this for initialization
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody> ();
		//characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		PlayerController();
	}

	public void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			isGrounded = true;
			isJumping = false;
		}
	}

	public void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			isGrounded = false;
			isJumping = true;
		}
	}


	public void PlayerController()
	{

		//basic movements:
		if(Input.GetKey(left))
		{
			transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
		}

		if(Input.GetKey(right))
		{
			transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
		}

		if(Input.GetKey(jump) && isGrounded == true)
		{
			rigidBody.AddForce(Vector3.up * jumpVelocity);
			print ("jump");
			isJumping = true;
		}

		if(Input.GetKey(crouch))
		{
			isCrouching = true;
		}

		if(Input.GetKeyUp(crouch))
		{
			isCrouching = false;
		}

		if (isJumping == true) //I don't think this is working the way I want it to. Whatever.
		{
			float timer = 0.0f;
			timer += Time.deltaTime;
			if(timer >= jumpTime)
			{
				rigidBody.AddForce(Vector3.down * jumpVelocity);
			}
		}


		//Attack/Block/Grab Commands:

		if(Input.GetKeyDown (attack))
		{
			Instantiate(attackHitBox, attackPosition.transform.position, attackPosition.transform.rotation);
			print ("attack");
		}
		if(Input.GetKeyDown (special))
		{
			Instantiate(specialHitBox, attackPosition.transform.position, attackPosition.transform.rotation);
			print ("special");
		}
		if(Input.GetKey (shield))
		{
			//activate shield
			print ("shielding");
		}
		if(Input.GetKeyDown (grab))
		{
			//Grab enemy
			print ("grabbing");
		}



		//In Case we need to go back:

//		float sideSpeed = Input.GetAxis ("Horizontal");
//		if(IsGrounded)
//			sideSpeed *= movementSpeed;
//		else
//			sideSpeed *= movementSpeed/2;
//		
//		verticalVelocity = IsGrounded ?  0 : verticalVelocity + -25f * Time.deltaTime;
//		if(IsGrounded && Input.GetButtonDown("Jump"))
//		{
//			verticalVelocity = jumpVelocity;
//		}
//		
//		Vector3 speed = new Vector3(sideSpeed, verticalVelocity);
//		
//		speed = transform.rotation * speed;
//		
//		characterController.Move(speed * Time.deltaTime);
	}
}
