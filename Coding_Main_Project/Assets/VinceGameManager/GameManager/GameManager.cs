using UnityEngine;
using System.Collections;

// consistant bracketing.
public class GameManager : MonoBehaviour {
    //you have a instance variable, but you never use it to get access to your GameManager. 
    //This is the correct approach and when you need access in other scripts, do a public GameManager gameManager = GameManager.instance; rather then a Find and Get Component.
	public static GameManager instance = null;
    //Should be selectedCharacters? seems like players != the character they selected.
	public GameObject[] players = null;
    //selectedStage seems more appropraite
	public GameObject selectedScene = null;

	void Awake()
	{
		instanceCheck ();
        //same as gameObject... transform is redundant here. Under the hood transform is gameObject.transform.. so your doing gameObject.transform.gameObject.
		DontDestroyOnLoad(transform.gameObject);
	}// consistant spacing.
	void Start () 
	{
	
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
}
