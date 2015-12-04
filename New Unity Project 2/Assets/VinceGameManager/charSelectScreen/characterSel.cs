using UnityEngine;
using System.Collections;

//Scripts ALWAYS start with capital letter. Never abreviate. 
//keep consistant bracket placement
public class characterSel : MonoBehaviour {

    //rename to gameManager. Stay consistant so people can expect consistant results, any time i want a gameManager i shouldnt have to guess what you named it.
	//public GameObject gameManage;
	public GameManager gameManager = null;
    //Make this generic so it can be on any slot and work.  Should be a public GameObject characterPrefab
	public GameObject kirbyPref = null;

	void Start () 
	{
		gameManager = GameManager.instance;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    //Needs to be generic, public void SelectCharacter, also needs to know what player selected it.
	public void SelectKirby()
	{
    	gameManager.activePlayers[0] = kirbyPref;
	}
    //this should be in a different script than this one? every slot to pick a character shouldnt have a start level.
	public void StartGame()
	{
		Application.LoadLevel ("BattleScene");
	}
}
