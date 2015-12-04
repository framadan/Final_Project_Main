using UnityEngine;
using System.Collections;

public class RayGun : MonoBehaviour 
{
	public GameObject projectile = null;
	public float coolDown = 0.0f;
	public AudioClip shotSound = null;
	public bool canFire = false;
	private float time = 0.0f;

	// Use this for initialization
	void Start () 
	{
		time = coolDown;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (time < coolDown)
			time += Time.deltaTime;
		if (time >= coolDown)
			canFire = true;
	}

	public void FireShot(ItemUser weilder)
	{
		if(canFire == true)
		{
			//play shotSound
			Instantiate (projectile, transform.position, transform.rotation);
			canFire = false;
			time = 0.0f;
		}

	}
}
