using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maniqui : MonoBehaviour
{
    public GameObject parte1;
    public GameObject parte2;
    public int progress;
    public float force;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            if(progress == 0)
            {
                progress++;

                Destroy(parte1);
                /* parte1.transform.parent = null;
               var dirForce = transform.position - collision.transform.position;
               parte1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
               parte1.GetComponent<Rigidbody>().useGravity = true;
               parte1.GetComponent<Rigidbody>().AddForce(dirForce * force);*/
            }
            else
            {
                /* parte2.transform.parent = null;
                 var dirForce = transform.position - collision.transform.position;
                 parte1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                 parte2.GetComponent<Rigidbody>().useGravity = true;
                 parte2.GetComponent<Rigidbody>().AddForce(dirForce * force);*/
                
                Destroy(gameObject);
                
            }
        }
    }
}
