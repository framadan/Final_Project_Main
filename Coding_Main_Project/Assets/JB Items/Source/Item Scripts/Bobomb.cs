using UnityEngine;
using System.Collections;

public class Bobomb : MonoBehaviour 
{
	 float direction = 1;


	public bool grounded = false;
	public bool atEdge = false;
	public bool primed = false;

	public float runTimer = 10;
	public float boomTimer = 10;

	public float Distance = 1000f;
	public float speed = 0.05f;

	void Update ()
	{
		if (gameObject.GetComponent<Item> ().beingHeld == true && !primed)
		{
			primed = true;
			StopAllCoroutines ();
		}
	}

	void Start () 
	{
		StartCoroutine (StartCountDown());
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Edge")
		{
			atEdge = true;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Edge")
		{
			atEdge = false;
		}
	}

	void Explode()
	{
		// Hit.
		Destroy (gameObject);
	}

	void GetGrabbed(GameObject wielder)
	{
		gameObject.transform.parent = wielder.transform;
		gameObject.GetComponent<Item> ().beingHeld = true;
		primed = true;
		StopAllCoroutines ();
	}

	IEnumerator StartCountDown()
	{
		yield return new WaitForSeconds(runTimer);
		StartCoroutine (BobombMovement ());
		StartCoroutine (ExplosionTimer ());
	}

	IEnumerator ExplosionTimer ()
	{
		yield return new WaitForSeconds(boomTimer);
		Explode ();
	}

	IEnumerator BobombMovement()
	{
		for (int i = 0; i < Distance; i++)
		{
			//Run Walking Animation
			gameObject.transform.Translate(Vector3.left * direction * speed);

			if(atEdge)
				break;
			yield return new WaitForSeconds(1f/60f);
		}

		//Run Turning Animation
		direction *= -1; // Change Direction

		StartCoroutine (BobombMovement ());
	}
}
