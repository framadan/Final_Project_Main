using UnityEngine;
using System.Collections;

public class PokeMovement : MonoBehaviour 
{

    public float timer;

    public GameObject squirt;
    public GameObject rock;
    public GameObject duck;
    public GameObject leaf;

    public float s = 1;
    public float r = 3;
    public float d = 3;
    public float l = 4;

    Vector3 rloc;
    Vector3 dloc;
    Vector3 lloc;

    // Use this for initialization
    void Start()
    {
        s = 0;
        r = 0;
        d = 0;
        l = 0;

        rloc = rock.transform.position;
        dloc = duck.transform.position;
        lloc = leaf.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        squirt.transform.Translate(Vector3.down * s * Time.deltaTime);
        rock.transform.Translate(Vector3.forward * r * Time.deltaTime);
        duck.transform.Translate(Vector3.up * d * Time.deltaTime);
        leaf.transform.Translate(Vector3.left * l * Time.deltaTime);
        if (timer >= 4)
        {
            s = 1;
        }

        if (timer >= 2)
        {
            r = 2;
        }
        if (timer >= 12)
        {
            r = 0;
        }
        if (timer >= 15)
        {
            d = 2;
            s = 0;
        }
        if (timer >= 18)
        {
            d = 0;
           
        }
        if (timer >= 22)
        {
            r = 4;
        }
        if (timer >= 28)
        {
            l = 4;
        }
        if (timer >= 28)
        {
            r = 0;
        }
        if (timer >= 34)
        {
            d = 4;
        }
        if (timer >= 31)
        {
            s = -1;
        }

        if (timer >= 38)
        {
            d = 0;
            l = 0;
        }
        if (timer >= 41)
        {
            s = 0;
        }
        if (timer >= 50)
        {
            rock.transform.position = rloc;
            duck.transform.position = dloc;
            leaf.transform.position = lloc;
            timer = 0;
        }
    }
}
