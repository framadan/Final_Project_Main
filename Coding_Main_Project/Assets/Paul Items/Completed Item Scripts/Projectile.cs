using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public float speed = 0.0f;
	public float damage = 0.0f;
	public float baseKnockBack = 0.0f;
	public GameObject particleEffect = null;

	public AudioClip hitSound = null;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}

	public void OnCollisionEnter(Collision other) //ready for use
	{
		/*
		if (other.gameObject.GetComponent<CharacterMovement> != null) 
		{ //tentative
			//Call damage function plug in damage and baseKnockBack
			//play audio
			Instantiate(particleEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		} 
		else
			Destroy (gameObject);
	*/
	 } 
}
