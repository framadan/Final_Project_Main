using UnityEngine;
using System.Collections;

public class WallJump : MonoBehaviour {
	public float Speed = 3f;
	public float GravityStrength = 5f;
	public float JumpSpeed = 10f;
	float verticalVelocity;
	Vector3 velocity;
	Vector3 groundedVelocity;
	bool WallJumping;

	void Update()
	{
		Vector3 myVector = new Vector3(0,0,0);

		if (CharacterController.isGrounded)
		{
			myVector.x = Imput.GetAxis("HOrizontal");
			myVector.y = Input.GetAxis("Vertical");
			myVector = Vector3.ClampMagnitude(myVector, 1f);
			myVector = myVector * Speed * Time.deltaTime;

		}
		else
		{
			myVector = groundedVelocity;
			myVector*= Time.deltaTime;
		}


	}
	void WallJumpCheck()
	{

		if(!isGrounded && ControllerColliderHit.tag == "Wall" && Input.GetKeyDown ("Jump"))
		{
			WallJumping()
		}
		else(!isGrounded && Input.GetKeyDown ("Jump"))
		{
			Debug.Log("You're in the air!")
		}
	}
	void OnControllerColliderHit(ConrollerColliderHit hit)
	{
		Vector3 normal = hit.normal;
		Vector3.Reflect()
	}
}
