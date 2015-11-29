using UnityEngine;
using System.Collections;

public class CharacterShield : MonoBehaviour
{

    public bool shieldActive = false;
    public int health = 0;
    public float timeForDamage = 0.0f;
    public float timeForActive = 0.0f;
    

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        ShieldActivity();
        ShieldState();
	}

    public void ShieldActivity()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (timeForActive <= 0.0f)
            {
                shieldActive = true;
            }
        }
        else
            shieldActive = false;
    }

    public void ShieldState()
    {
        if (shieldActive == true)
        {
            timeForDamage -= Time.deltaTime;

            if (timeForDamage <= 0.0f)
            {
                health -= 1;
                timeForDamage = 5.0f;
                shieldActive = false;
                timeForActive = 3.0f;
            }
        }
        else
            timeForDamage = 5.0f;
        if (timeForActive >= 3.0f || timeForActive<= 3.0f)
        {
            timeForActive = timeForActive - Time.deltaTime;
            if (timeForActive <= 0.0f)
            {
                timeForActive = 0.0f;
            }
        }
    }
}
