using UnityEngine;
using System.Collections;

public class Fox : AI_Main_02
{
    public float counter = 0;
    public GameObject spawner;
    public GameObject fox1;
    public GameObject fox2;
    public GameObject fox3;
    public GameObject fox4;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            rigidbody.velocity = Vector3.zero;
            this.gameObject.GetComponent<BaseAbility>().health = 10;
            this.gameObject.GetComponent<BaseAbility>().baseKB = 10;
            this.gameObject.transform.position = spawner.transform.position;
            counter++;
        }
        if (other.gameObject.tag == "Side")
        {
            transform.Translate(0, 10, 0);
        }
    }
    public virtual void LateUpdate()
    {
        CounterCheck();
    }
    void CounterCheck()
    {
        if (counter == 1)
        {
            fox1.SetActive(false);
        }
        if (counter == 2)
        {
            fox2.SetActive(false);
        }
        if (counter == 3)
        {
            fox3.SetActive(false);
        }
        if (counter >= 4)
        {
            fox4.SetActive(false);
            Destroy(self);
        }
    }

}
