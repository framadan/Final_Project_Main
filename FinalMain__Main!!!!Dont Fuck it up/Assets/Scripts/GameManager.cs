using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UnityEngine.UI.Text textGameObject;
    public float percent;
    public GameObject gamemanager;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        Text text = textGameObject.GetComponent<Text>();
        text.text = gamemanager.GetComponent<GameManager>().percent + "%";
	}
}
