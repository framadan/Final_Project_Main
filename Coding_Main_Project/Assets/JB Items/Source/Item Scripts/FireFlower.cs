using UnityEngine;
using System.Collections;

public class FireFlower : MonoBehaviour 
{
	public int Ammo = 0;
	public int ammoCost = 0;
	public float fireRate = 0.0f;
	private float time = 0.0f;

	public bool isFiring = false;

	public GameObject flamePrefab = null;
	public GameObject smokePrefab = null;
	public GameObject[] flamePlacement;

	// Use this for initialization
	void Start () 
	{
		isFiring = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		time += Time.deltaTime;
		if (isFiring == true)
			ShootFire ();
	}
	public void ShootFire()
	{
		for (int i = 0; i <= flamePlacement.Length; i++) //Cycle through instantiate points
		{
			if(ammoCost <= Ammo)
			{
				Instantiate (flamePrefab, flamePlacement[i].transform.position, flamePlacement[i].transform.rotation);
				Ammo--;
					
					if(i > flamePlacement.Length && isFiring == true) //If player keeps firing through rotation of instantiate points
						i = 0;
			}
			if(ammoCost > Ammo)
			{
				Instantiate (smokePrefab, flamePlacement[i].transform.position, flamePlacement[i].transform.rotation);
					
					if(i > flamePlacement.Length && isFiring == true)
						i = 0;
			}
		}
	}
}
