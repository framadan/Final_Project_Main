using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour
{

    //public List<Transform> playerTransforms = new List<Transform>();

    //public Transform player;

    //Note: Some of these variables need to be set to private. Only set to public as of right now just to see
    //      the values in the inspector. - Eric S. 11/29/2015
    public float cameraPositionZ;
    public float cameraPositionZOffset = 0.0f;
    public float cameraPositionZLimit = 0.0f;

    public float playerOnePositionZ;
    public float playerTwoPositionZ;
    public float playerThreePositionZ;
    public float playerFourPositionZ;
    public float lerpSpeed = 0.0f;


	// Use this for initialization
	void Start ()
    {
        
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
        playerOnePositionZ = camDistanceDetectorScript.playerOneDistance;
        playerTwoPositionZ = camDistanceDetectorScript.playerTwoDistance;
        playerThreePositionZ = camDistanceDetectorScript.playerThreeDistance;
        playerFourPositionZ = camDistanceDetectorScript.playerFourDistance;
    }

    public void CameraPositionDetection()
    {
        cameraPositionZ = -playerOnePositionZ + -playerTwoPositionZ + -playerThreePositionZ + -playerFourPositionZ + -cameraPositionZOffset;
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
