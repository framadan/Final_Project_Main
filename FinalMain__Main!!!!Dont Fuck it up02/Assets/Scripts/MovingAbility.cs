using UnityEngine;
using System.Collections;

public class MovingAbility : MonoBehaviour
{
    public float speed = 6f;
    public float damage = 2;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<BaseAbility>().KnockBack(5f);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }
    }
}
