using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public GameObject[] players = null;
	public GameObject selectedScene = null;

	void Awake()
	{
		instanceCheck ();
		DontDestroyOnLoad(transform.gameObject);
	}
	void Start () 
	{
	
	}
	

	void Update () 
	{
	
	}
	void instanceCheck()
	{
		if (instance == null) 
			instance = this;
		 else if (instance != this) 
			Destroy (gameObject);
	}
}
