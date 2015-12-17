using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour
{
    public float force = 600.0f;
    public float timeSpentActive = 0.3f;

    // Update is called once per frame
    void Update()
    {
        TriggerDestroy();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.rigidbody.AddForce(transform.up * force);
            other.rigidbody.useGravity = true;
        }
    }

    void TriggerDestroy()
    {
        timeSpentActive -= Time.deltaTime;
        if (timeSpentActive <= 0)
        {
            Destroy(gameObject);
        }
    }
}
