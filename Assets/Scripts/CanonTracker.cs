using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTracker : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.LookAt(other.transform);

            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {

    }
}
