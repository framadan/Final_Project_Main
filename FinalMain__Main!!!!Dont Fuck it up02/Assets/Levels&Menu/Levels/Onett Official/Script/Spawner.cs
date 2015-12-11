using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public GameObject carPrefabs = null;
	public GameObject[] enemySpawnPoints;
	public float spawnDelay = 3.0f;
	public float timer = 0.0f;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		
		if (timer >= spawnDelay) 
		{
			int randomNumber = Random.Range(0, enemySpawnPoints.Length);
			Instantiate (carPrefabs, enemySpawnPoints[randomNumber].transform.position, transform.rotation);
			timer = 0.0f;
		}
	}
}
