using UnityEngine;
using System.Collections;

public class WallJump : MonoBehaviour {
	

	void WallJumpCheck()
	{

		if(!isGrounded && ControllerColliderHit.tag == "Wall" && Input.GetKeyDown ("Jump"))
		{
			WallJump()
		}
		else(!isGrounded && Input.GetKeyDown ("Jump"))
		{
			Debug.Log("You're in the air!")
		}
	}

	void WallJump()
	{


	}

}
