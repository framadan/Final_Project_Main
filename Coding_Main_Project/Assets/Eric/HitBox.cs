using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour
{
    public float force = 600.0f;
    public float timeSpentActive = 0.3f;

    public GameObject hitBoxSpawner = GameObject.FindWithTag("HitBoxTrigger");

    // Update is called once per frame
    void Update()
    {
        TriggerDestroy();
        TriggerPosition();
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

    //folows HitBoxSpawner
    void TriggerPosition()
    {
        transform.position = hitBoxSpawner.transform.position;
    }
}
