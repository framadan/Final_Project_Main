using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI_Main_02 : MonoBehaviour 
{
    public float coTime;
    public float Hop = 20f;
	public float jump = 600f;
	public Collider[] possibleTargets;
	public float speed;
	public float aggro = 10f;
	public GameObject currentTarget;
	public bool showDebug = false;
	public Color aggroRadiusColor;
	public GameObject self;
	public float delayTime;
	public float delay = 2f;
	//public Transform target;
    public Rigidbody rigidbody;
    
	// Use this for initialization
	void Start () 
	{
        rigidbody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        //JumpTimer();
        Targeting();
    }

    void DrawGismos()
	{
		if (showDebug != true)
			return;
		Gizmos.color = aggroRadiusColor;
		Gizmos.DrawSphere (transform.position, aggro);
		if (currentTarget != null) 
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine (transform.position, currentTarget.transform.position);
		}
	}

	void Targeting()
	{
        possibleTargets = Physics.OverlapSphere (transform.position, aggro);
		foreach(Collider possibleTarget in possibleTargets)
        {
            if(possibleTarget.tag != "Player")
            {
                continue;
            }
            if (currentTarget == null)
            {
                currentTarget = possibleTarget.gameObject;
            }
            if(currentTarget == this.gameObject)
            {
                currentTarget = null;
            }
            if (currentTarget)
            {
                transform.LookAt(new Vector3(currentTarget.transform.position.x, transform.position.y, currentTarget.transform.position.z));
                this.rigidbody.AddRelativeForce(Vector3.forward * speed);
            }
        }
	}
    /*public void JumpTimer()
    {
        if(Time.time >= delayTime)
        {
            self.GetComponent<Rigidbody>().AddForce(Vector3.up * Hop);
            delayTime = Time.time + delay;
            StartCoroutine(Timer(coTime));
        }
    }
    IEnumerator Timer (float timer)
    {
        yield return new WaitForSeconds(timer);
    }*/
}