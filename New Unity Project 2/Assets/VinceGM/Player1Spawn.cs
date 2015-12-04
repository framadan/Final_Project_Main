using UnityEngine;
using System.Collections;

public class Player1Spawn : MonoBehaviour {
	public GameObject gameManage;
	public GameObject player1Prefab = null;
	void Start () 
	{
		gameManage = GameObject.Find ("GameManager");
		player1Prefab = gameManage.GetComponent<GameManager> ().player1;
		Instantiate (player1Prefab);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
