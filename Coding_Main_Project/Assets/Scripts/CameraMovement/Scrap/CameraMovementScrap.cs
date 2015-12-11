using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CameraMovementScrap : MonoBehaviour
{

    //public List<Transform> playerTransforms = new List<Transform>();
	public float xMin = 0, xMax = 0, yMax = 0;
	public List<float> yPosition = new List<float> ();
	public List<GameObject> players = new List<GameObject> ();
	public GameObject player;


    //Note: Some of these variables need to be set to private. Only set to public as of right now just to see
    //      the values in the inspector. - Eric S. 11/29/2015
    public float cameraPositionZ;
    public float cameraPositionZOffset = 0.0f;
    public float cameraPositionZLimit = 0.0f;

	public float DistanceForPlayers;
//    public float playerOnePositionZ;
//    public float playerTwoPositionZ;
//    public float playerThreePositionZ;
//    public float playerFourPositionZ;s
    public float lerpSpeed = 0.0f;


	// Use this for initialization
	void Start ()
    {
		players = GameObject.FindGameObjectsWithTag ("Player").ToList(); //FML...This could have saved me before.

    }

    void Update()
    {
        PlayerPositionDetection();
        CameraPositionDetection();
    }

	void LateUpdate ()
    {
        CameraMovementFunction();
    }

    public void PlayerPositionDetection()
    {
        GameObject camDistanceDetector = GameObject.Find("CamDistanceDetector");
        CameraDistanceDetecter camDistanceDetectorScript = camDistanceDetector.GetComponent<CameraDistanceDetecter>();
		DistanceForPlayers = camDistanceDetectorScript.playerObjectsDistance;

//        playerOnePositionZ = camDistanceDetectorScript.playerOneDistance;
//        playerTwoPositionZ = camDistanceDetectorScript.playerTwoDistance;
//        playerThreePositionZ = camDistanceDetectorScript.playerThreeDistance;
//        playerFourPositionZ = camDistanceDetectorScript.playerFourDistance;
    }

    public void CameraPositionDetection()
    {
//		cameraPositionZ = -playerOnePositionZ + -playerTwoPositionZ + -playerThreePositionZ + -playerFourPositionZ + -cameraPositionZOffset;
//        if (cameraPositionZ <= cameraPositionZLimit)
//        {
//            cameraPositionZ = cameraPositionZLimit;
//        }

		cameraPositionZ =  DistanceForPlayers + cameraPositionZOffset;
		if (cameraPositionZ <= cameraPositionZLimit)
		{
			cameraPositionZ = cameraPositionZLimit;
		}
    }

    public void CameraMovementFunction()
    {
        //transform.position = Vector3.Lerp (transform.position,new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z),Time.deltaTime * lerpSpeed);
        //transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, cameraPositionZ), Time.deltaTime * lerpSpeed);
    }
}
