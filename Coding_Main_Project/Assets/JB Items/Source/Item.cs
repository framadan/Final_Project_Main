using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour 
{
	public Items item = Items.None;

	public bool beingHeld = false;
	public bool despawn = true;
	public bool consumable = false;

	public float despawnTimer = 30f;

	public void GetGrabbed(GameObject wielder)
	{
		// Running the Consumables' functions. 
		if (consumable)
		{
			if (gameObject.GetComponent<MetalBox>() != null)
			{
//				gameObject.GetComponent<MetalBox>().DoTheDo(wielder.GetComponent<ItemUser>());
			}

			if (gameObject.GetComponent<StarMan>() != null)
			{
				gameObject.GetComponent<StarMan>().DoTheDo(wielder.GetComponent<ItemUser>());
			}

			Destroy (gameObject);
			return;
		}

		// Assign References and flip bools.
		wielder.GetComponent<ItemUser>().item = item;
		gameObject.transform.parent = wielder.transform;
		beingHeld = true;
		despawn = false;
	}

	void Update() // Despawn Timer.
	{
		if (despawn)
		{
			if (despawnTimer < 0) // Time is up.
			{
				Destroy(gameObject);
				print (gameObject.name + " Despawned. ");
			}
			else // Time is still going.  
			{
				despawnTimer -= Time.deltaTime;
			}
		}
	}

	void Start ()
	{
		despawn = true;

		if (item == Items.MaxTomato || item == Items.MetalBox)
		{
			consumable = true;
		}
	}
}