using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    static TimeManager instance;
	// Use this for initialization
	void Awake ()
    {
        instance = this;
	}
	
}
