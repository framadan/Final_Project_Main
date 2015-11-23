using UnityEngine;
using System.Collections;

public class characterSel : MonoBehaviour {

	public GameObject gameManage;
	public GameObject kirbyPref = null;

	void Start () 
	{
		gameManage = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void SelectKirby()
	{
		gameManage.GetComponent<GameManager> ().players[0] = kirbyPref;
	}
	public void StartGame()
	{
		Application.LoadLevel ("BattleScene");
	}
}
