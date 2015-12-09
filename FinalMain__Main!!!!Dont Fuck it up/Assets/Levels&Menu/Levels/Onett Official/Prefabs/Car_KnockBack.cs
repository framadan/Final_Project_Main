using UnityEngine;
using System.Collections;

public class Car_KnockBack : MonoBehaviour
{
    public float damage = 5f;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<BaseAbility>().TakeDamage(damage);
        }
    }
}
