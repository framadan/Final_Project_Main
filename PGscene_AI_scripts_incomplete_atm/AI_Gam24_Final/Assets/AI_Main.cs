using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AI_Main : MonoBehaviour 
{
    public float jump = 600f;

    public Collider[] possibleTargets;
	public float speed;
    public float aggro = 100f;
	public GameObject currentTarget;

	public bool showDebug = false;
	public Color aggroRadiusColor;
	public int health;
	public GameObject self;
	public float knockBack = 2;
	public float delayTime;
	public float delay = 2f;
	public GameObject ledgegrab;
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
	void Start () 
	{
		ledgegrab = GameObject.FindGameObjectWithTag ("Ledge");
	}


    void Update()
    {
        possibleTargets = Physics.OverlapSphere(transform.position, aggro);
        foreach (Collider possibleTarget in possibleTargets)
        {
            if (possibleTarget.tag != "Target")
            {
                continue;
            }
            if (currentTarget == null)
            {
                currentTarget = possibleTarget.gameObject;
            }
            if (Vector3.Distance(gameObject.transform.position, currentTarget.transform.position) <= 1f)
            {
                currentTarget = null;
            }

            else
            {
                if (Vector3.Distance(transform.position, currentTarget.transform.position) >
                   Vector3.Distance(transform.position, possibleTarget.gameObject.transform.position))
                {
                    currentTarget = possibleTarget.gameObject;
                }
            }
        }
        if (currentTarget)
        {
            Vector3 direction = (currentTarget.transform.position - transform.position).normalized;

            gameObject.transform.LookAt(currentTarget.transform);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            return;
        }
        if (Time.time >= delayTime)
        {
            self.layer = LayerMask.NameToLayer("Phasing");
            self.GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
            delayTime = Time.time + delay;
            StartCoroutine(Timer(2));
        }
    }
    IEnumerator Timer(float timer)
    {
        yield return new WaitForSeconds(timer);
        self.layer = LayerMask.NameToLayer("Default");
    }

    /*if (Vector3.Distance (gameObject.transform.position, ledgegrab.transform.position) <= 5.0f) 
    {
        gameObject.transform.LookAt(ledgegrab.transform);
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * knockBack);

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }*/
    /*
            }
            if (Vector3.Distance (gameObject.transform.position, currentTarget.transform.position) <= 8.0f)
            {
                Animation.Play("HeavyPunch");
            }
            if (Vector3.Distance (gameObject.transform.position, currentTarget.transform.position) <= 12.0f) 
            {
                Animation.Play("RangedAttack");
            }
            if (Vector3.Distance (gameObject.transform.position, currentTarget.transform.position) <= 5.0f) 
            {
                Animation.Play("Block");
            }	*/

    public void KnockBack(float value)
	{
		Vector3 direction = transform.InverseTransformDirection (0,1,1);
		this.GetComponent<Rigidbody>().AddForce(direction * value);
	}
}






