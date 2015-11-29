using UnityEngine;
using System.Collections;

public class CameraDistanceDetecter : MonoBehaviour
{

    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;

    public float playerOneDistance;
    public float playerTwoDistance;
    public float playerThreeDistance;
    public float playerFourDistance;

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
        playerOne = GameObject.FindWithTag("PlayerOne");
        playerTwo = GameObject.FindWithTag("PlayerTwo");
        playerThree = GameObject.FindWithTag("PlayerThree");
        playerFour = GameObject.FindWithTag("PlayerFour");
    }

    public void PlayerDistanceFinder()
    {
        playerOneDistance = Vector3.Distance(playerOne.transform.position, transform.position);
        playerTwoDistance = Vector3.Distance(playerTwo.transform.position, transform.position);
        playerThreeDistance = Vector3.Distance(playerThree.transform.position, transform.position);
        playerFourDistance = Vector3.Distance(playerFour.transform.position, transform.position);
    }
}
