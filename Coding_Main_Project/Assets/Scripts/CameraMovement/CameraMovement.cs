using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour
{

    public List<Transform> playerTransforms = new List<Transform>();
    public Transform player;
    public Transform randomObject;
    public float lerpSpeed = 0.0f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	
	void LateUpdate ()
    {
        transform.position = Vector3.Lerp (transform.position,new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z),Time.deltaTime * lerpSpeed);
        transform.position = Vector3.Lerp(transform.position, new Vector3(randomObject.transform.position.x, randomObject.transform.position.y, transform.position.z), Time.deltaTime * lerpSpeed);
    }
}
