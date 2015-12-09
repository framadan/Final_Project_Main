using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseAbility : MonoBehaviour 
{
    public float health = 10;
	public float damage;
	public float weight;
	public float scaledKB;
	public float baseKB;
	public float factors;
	float formula;
    public GameObject equalTarget;
    public bool hasHit;
	// Use this for initialization
	void Start () 
	{
        
	}
	
	// Update is called once per frame
	void Update () 
	{
        //formula = (((((health / 10f + health * damage / 20f) * weight * 1.4f) + 18f) * scaledKB) + baseKB) * factors;
        //print(formula);
    }
	
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            equalTarget = other.gameObject;
            if (equalTarget == other.gameObject)
            {
                equalTarget.GetComponent<BaseAbility>().KnockBack(formula);
                equalTarget.GetComponent<BaseAbility>().TakeDamage(damage);
            }
        }
    }
    
    public virtual void TakeDamage(float damage)
	{
        KnockBack(damage);
        health += damage; //+= baseKB;
        if (health >= 50f)
        {
            //damage += 2f;
            baseKB += 2f;
        }
        else if (health >= 100f)
        {
            //damage += 2f;
            baseKB += 2f;
        }
        else if (health >= 150f)
        {
            //damage += 2f;
            baseKB += 2f;
        }
        else if (health >= 200f)
        {
            //damage += 2f;
            baseKB += 2f;
        }
        else if (health >= 250f)
        {
            //damage += 2f;
            baseKB += 2f;
        }
        else if (health >= 300f)
        {
            //damage += 2f;
            baseKB += 2f;
        }
	}
    public virtual void KnockBack(float value)
    {
        float num = (((((health / 10f + health * damage / 20f) * weight * 1.4f) + 18f) * scaledKB) + baseKB) * factors;
        //float num = (((((health / 10f + health * value / 20f) * weight * 1.4f) + 18f) * scaledKB) + baseKB) * factors;
        //formula = (((((health / 10f + health * damage / 20f) * weight * 1.4f) + 18f) * scaledKB) + baseKB) * factors;
        print(num);
        Vector3 direction = transform.InverseTransformDirection(0, 1, -1);
        equalTarget.gameObject.GetComponent<Rigidbody>().AddForce(direction * num);
    }
}

//Links
//http://www.ssbwiki.com/knockback
//http://www.ssbwiki.com/Kirby_(SSBB)
//
