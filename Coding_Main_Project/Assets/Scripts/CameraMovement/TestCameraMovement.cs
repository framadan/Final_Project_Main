﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestCameraMovement : MonoBehaviour
{

    public List<float> xPosition = new List<float>();
    public List<float> yPosition = new List<float> ();
    public List<GameObject> targets = new List<GameObject>();
    public GameObject[] players;

    public float maxXPosiion = 0.0f;
    public float maxYPosiion = 0.0f;
    public float maxZPosition = 0.0f;

    public float minXPosition = 0.0f;
    public float minYPosition = 0.0f;
    public float minZPosition = 0.0f;

	// Use this for initialization
	void Start ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (GameObject player in players)
        {
            xPosition.Add(player.transform.position.x);
            yPosition.Add(player.transform.position.y);
        }
	}
}