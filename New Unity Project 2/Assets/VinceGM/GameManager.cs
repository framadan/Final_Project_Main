using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player1 = null;
	public GameObject player2 = null;
	public GameObject player3 = null;
	public GameObject player4 = null;
	public GameObject scene = null;

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
	void Start () 
	{
	
	}
	

	void Update () 
	{
	
	}
}
