using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour 
{
    //wyatts comments:
    // name this gameManager not gM
	public GameManager gM;
    //name this spawnPoints[]
	public GameObject[] pSpawners = null;

    //maybe an int currentPlayers then?
	int maxPlayers = 4;// connected players will alter value

	void Awake()
	{
		gM = GetComponent<GameManager> ();
		SpawnSet ();
	}
	void Start () 
	{
		instPlayers ();
	}
	
	// keep bracketing consistant
	void Update () {
	
	} 

    //Rename to InitializeSpawnPoints
	void SpawnSet()
	{
        //seems like a costly way to do this, find a different way.
		pSpawners[0]= GameObject.Find ("P1Spawner");
		pSpawners[1] = GameObject.Find ("P2Spawner");
		pSpawners[2] = GameObject.Find ("P3Spawner");
		pSpawners[3] = GameObject.Find ("P4Spawner");
	}

    //Keep consistant Cammel Casing on Functions. Should start with a capital.  Also dont abreviate in Method names, makes it unclear whats happening.
    //Rename this
	void instPlayers()
	{
		for(int i = 0; i < maxPlayers; i++)
		{
            // fix indentation here.
		Instantiate (gM.players[i],pSpawners[i].transform.position,transform.rotation);
		}
		
	}
}
