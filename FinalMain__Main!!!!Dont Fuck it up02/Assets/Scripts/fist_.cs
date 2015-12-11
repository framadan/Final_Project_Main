using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fist_ : MonoBehaviour
{
    public float health = 10;
    public float damage;
    public float weight;
    public float scaledKB;
    public float baseKB;
    public float factors;
    float formula;
    public GameObject equalTarget;
    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Punching");
            other.gameObject.GetComponent<BaseAbility>().KnockBack(formula);
            other.gameObject.GetComponent<BaseAbility>().TakeDamage(damage);
        }
    }
    public virtual void KnockBack(float value)
    {
        float num = (((((health / 10f + health * damage / 20f) * weight * 1.4f) + 18f) * scaledKB) + baseKB) * factors;
        //float num = (((((health / 10f + health * value / 20f) * weight * 1.4f) + 18f) * scaledKB) + baseKB) * factors;
        //formula = (((((health / 10f + health * damage / 20f) * weight * 1.4f) + 18f) * scaledKB) + baseKB) * factors;
        //print(num);
        Vector3 direction = transform.InverseTransformDirection(0, 1, -1);
        gameObject.GetComponent<Rigidbody>().AddForce(direction * num);
    }
}
