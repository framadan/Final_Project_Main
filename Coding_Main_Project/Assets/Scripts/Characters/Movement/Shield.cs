using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{
    public float shieldTimer = 10f;
    public bool shieldOn = false;
    public bool shieldRecharge = true;
    public bool shieldBreak = false;
   

    //Just for now, waiting for actual damage values
    public bool damageTaken = false;
    //Used for testing if shield would take damage
    public float lowDamage = 0.5f;
    public float medDamge = 1.5f;
    public float hihDamge = 2.5f;

    //public bool playerHit = false;



    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Shielded();
        ShieldRecharge();
        ShieldBreak();
	}


    void Shielded()
    {
        if (Input.GetKey(KeyCode.LeftShift))//GetButtonDown will be used when we have a control scheme setup
        {
            //State where shield actions are on and unable to move, but able to Rdodge
            shieldOn = true;
            shieldRecharge = false;
            shieldTimer -=  Time.deltaTime ;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shieldOn = false;
            shieldRecharge = true;
        }
    }

    //this is just a quick thing to see if it works
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Cube")
        {
            damageTaken = true;
            shieldTimer -= lowDamage;
        }
    }

    void ShieldRecharge()
    {
        if (shieldRecharge == true && shieldTimer < 10)
        {
            shieldTimer += Time.deltaTime * 1f;
        }
        if (shieldRecharge == true && shieldTimer == 10)
        {
            shieldRecharge = false;
        }
    }

    void ShieldBreak()
    {
        if (shieldTimer <= 0)
        {
            shieldBreak = true;
        }
        if (shieldBreak == true)
        {
            //states
        }
    }
}
