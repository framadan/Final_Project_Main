using UnityEngine;
using System.Collections;

public class FireFlower : ItemBase 
{
	public int Ammo = 0;
	public int ammoCost = 0;
	public float fireRate = 0.0f;
	private float time = 0.0f;

	public bool isFiring = false;
	bool isOutOfAmmo = false;

	public GameObject flamePrefab = null;
	public GameObject smokePrefab = null;
	public GameObject[] flamePlacement;

	public AudioClip fireSound = null;
	public AudioClip smokeSound = null;

//	public override void Stop ()
//	{
//		isFiring = false;
//		StartCoroutine (Fire ());
//	} don't think this is necessary

	public override void Use ()
	{
		isFiring = true;
	}

	public override void StopUse()
	{
		isFiring = false;
	}

	IEnumerator Fire()
	{
		while (isFiring)
		{
			if(ammoCost <= Ammo) //check for ammo
			{
				int temp = Random.Range(0, flamePlacement.Length-1); //pick random spot to spawn fire
				Instantiate (flamePrefab, flamePlacement[temp].transform.position, flamePlacement[temp].transform.rotation);
				//play fireSound(one shot)
				Ammo--;
			}
			if(ammoCost > Ammo)
			{
				int temp = Random.Range(0, flamePlacement.Length-1);
				Instantiate (smokePrefab, flamePlacement[temp].transform.position, flamePlacement[temp].transform.rotation);
				//play smokeSound(one shot)
			}
			yield return new WaitForSeconds (fireRate); //Pick how long to wait before creating another fire/smoke prefab
		}
	}
}


