using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

   // public float cameraPositionZ;
   // public float cameraPositionZLimit;
   //public float distanceForPlayers;

    public float cameraDistanceOne;
    public float cameraDistanceTwo;
    public float cameraPositionZ;
    public float cameraPositionZOffset = 10.0f;

    public float lerpSpeed = 10.0f;

	// Use this for initialization
	public void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerPositionDetection();
        CameraPositionDetection();
    }

    void LateUpdate()
    {
        CameraMovementFunction();
    }

    public void PlayerPositionDetection()
    {
        GameObject camTriggerOne = GameObject.FindWithTag("CameraTriggerOne");
        CameraTrigger1 camTriggerOneScript = camTriggerOne.GetComponent<CameraTrigger1>();
        cameraDistanceOne = camTriggerOneScript.distanceOne;

        GameObject camTriggerTwo = GameObject.FindWithTag("CameraTriggerTwo");
        CameraTrigger2 camTriggerTwoScript = camTriggerTwo.GetComponent<CameraTrigger2>();
        cameraDistanceTwo = camTriggerTwoScript.distanceTwo;

        cameraPositionZ = cameraDistanceOne + cameraDistanceTwo + cameraPositionZOffset;
    }

    public void CameraPositionDetection()
    {
        //cameraPositionZ = cameraDistanceOne + cameraDistanceTwo;
        //cameraPositionZ = -distanceForPlayers + -cameraPositionZOffset;
        //if (cameraPositionZ <= cameraPositionZLimit)
       // {
        //    cameraPositionZ = cameraPositionZLimit;
       // }
    }

    void CameraMovementFunction()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, cameraPositionZ), Time.deltaTime * lerpSpeed);
    }
}
