using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	//Player Movement
	public float movementSpeed = 0.0f;
	public float mouseSensitivity = 0.0f;
	public float jumpVelocity = 0.0f;
	
	public float upDownRotationLimit = 0.0f;
	float verticalVelocity = 0.0f;

	CharacterController characterController = null;

	public bool IsGrounded
	{
		get{return characterController.isGrounded;}
	}

	// Use this for initialization
	void Start () 
	{
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		PlayerController();
	}

	public void PlayerController()
	{
		float sideSpeed = Input.GetAxis ("Horizontal");
		if(IsGrounded)
			sideSpeed *= movementSpeed;
		else
			sideSpeed *= movementSpeed/2;
		
		verticalVelocity = IsGrounded ?  0 : verticalVelocity + -25f * Time.deltaTime;
		if(IsGrounded && Input.GetButtonDown("Jump"))
		{
			verticalVelocity = jumpVelocity;
		}
		
		Vector3 speed = new Vector3(sideSpeed, verticalVelocity);
		
		speed = transform.rotation * speed;
		
		characterController.Move(speed * Time.deltaTime);
	}
}
