using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour
{
    public float force = 600.0f;

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.rigidbody.AddForce(transform.up * force);
            other.rigidbody.useGravity = true;
        }
    }
}
