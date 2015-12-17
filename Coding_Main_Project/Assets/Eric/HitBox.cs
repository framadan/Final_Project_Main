using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.rigidbody.AddForce(transform.right * 600);
        }
    }
}
