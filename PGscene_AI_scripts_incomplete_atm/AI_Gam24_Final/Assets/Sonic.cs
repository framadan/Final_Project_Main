using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sonic : AI_Main_02
{
    public int damage = 25;
    public bool jumping;
    public float counter = 0;
    public GameObject spawner;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            self.gameObject.transform.position = spawner.transform.position;
            self.GetComponent<Rigidbody>().AddForce(Vector3.zero);
            counter++;
        }
        if (counter >= 4)
        {
            Destroy(self);
        }
    }
}
