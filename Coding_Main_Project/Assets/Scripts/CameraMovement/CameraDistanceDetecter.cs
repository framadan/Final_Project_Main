using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class CameraDistanceDetecter : MonoBehaviour
{
	public List<GameObject> playerObjects;
	public PlayerMovement[] movementArray = null;
	public float playerObjectsDistance;
	public CameraMovement cameraMovement = null;

//    public GameObject playerOne;
//    public GameObject playerTwo;
//    public GameObject playerThree;
//    public GameObject playerFour;

//    public float playerOneDistance;
//    public float playerTwoDistance;
//    public float playerThreeDistance;
//    public float playerFourDistance;

	// Use this for initialization
	void Start ()
    {
        PlayerFinder();
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerDistanceFinder();
    }

    public void PlayerFinder()
    {
		movementArray =  (PlayerMovement[])GameObject.FindObjectsOfType (typeof(PlayerMovement));
		foreach (PlayerMovement temp in movementArray) 
		{
			playerObjects.Add(temp.gameObject);
		}

//        playerOne = GameObject.FindWithTag("PlayerOne");
//        playerTwo = GameObject.FindWithTag("PlayerTwo");
//        playerThree = GameObject.FindWithTag("PlayerThree");
//        playerFour = GameObject.FindWithTag("PlayerFour");
    }

    public void PlayerDistanceFinder()
    {
		float xMin = 0;
		float xMax = 0;
		for (int i =0; i < playerObjects.Count; i ++) 
		{
			if (i == 0) {
				xMin = playerObjects [i].transform.position.x;
				xMax = playerObjects [i].transform.position.x;
				//cameraMovement.yMax = playerObjects[i].transform.position.x;
				continue;
			}

			if (playerObjects [i].transform.position.x < xMin) {
				xMin = playerObjects [i].transform.position.x;
			} else if (playerObjects [i].transform.position.x > xMax) {
				xMax = playerObjects [i].transform.position.x;
			}
		}
		cameraMovement.xMax = xMax;
		cameraMovement.xMin = xMin;

        //playerOneDistance = Vector3.Distance(playerOne.transform.position, transform.position);
       // playerTwoDistance = Vector3.Distance(playerTwo.transform.position, transform.position);
       // playerThreeDistance = Vector3.Distance(playerThree.transform.position, transform.position);
        //playerFourDistance = Vector3.Distance(playerFour.transform.position, transform.position);
    }
}
