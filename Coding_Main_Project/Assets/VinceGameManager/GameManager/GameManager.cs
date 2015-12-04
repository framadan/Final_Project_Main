using UnityEngine;
using System.Collections;

// consistant bracketing.
public class GameManager : MonoBehaviour 
{
	public static GameManager instance = null;
	bool battleActive = false;
	public GameObject[] spawnPoints = null;
    

	//active players
	public GameObject[] activePlayers = null;
	int maxPlayers = 4;

    //character prefabs
	public GameObject kirbyPref = null;

	//stage top be loaded;
	public GameObject selectedStage = null;

	void Awake()
	{
		instanceCheck ();       
		DontDestroyOnLoad(gameObject);
		if (battleActive == true) 
		{
			SpawnSet ();
		}
	}
	void Start () 
	{
	 if (battleActive == true) 
		{
			//instPlayers ();
		}
	}
	

	void Update () 
	{
	
	}
    //Consistant spacing between functions to help readability. Also Consistant Cammel casing. Methods ALWAYS start with a capitol
	void instanceCheck()
	{
		if (instance == null) 
			instance = this;
		 else if (instance != this) 
			Destroy (gameObject);
	}
	//character selectionScreem-------------------------------------
	public void SelectKirby()
	{
		activePlayers [0] = kirbyPref;
	}
	public void SelectChar2()
	{
		activePlayers [0] = kirbyPref;
	}
	public void SelectChar3()
	{
		activePlayers [0] = kirbyPref;
	}
	public void SelectChar4()
	{
		activePlayers [0] = kirbyPref;
	}
	public void SelectChar5()
	{
		activePlayers [0] = kirbyPref;
	}
	public void SelectChar6()
	{
		activePlayers [0] = kirbyPref;
	}
	public void SelectChar7()
	{
		activePlayers [0] = kirbyPref;
	}
	public void StartGame()
	{
		Application.LoadLevel (0);
		print ("test");
		battleActive = true;
	}//end character selection screen------------------------------
	//battleScene--------------------------------------------------
	void SpawnSet()
	{
		spawnPoints[0]= GameObject.Find ("P1Spawner");
		spawnPoints[1] = GameObject.Find ("P2Spawner");
		spawnPoints[2] = GameObject.Find ("P3Spawner");
		spawnPoints[3] = GameObject.Find ("P4Spawner");
	}
	void instPlayers()
	{
		for(int i = 0; i < maxPlayers; i++)
		{

			Instantiate (activePlayers[i],spawnPoints[i].transform.position,transform.rotation);
		}
		
	}
	//end battle Scene-----------------------------------------------
}

