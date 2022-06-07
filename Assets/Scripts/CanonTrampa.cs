using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTrampa : MonoBehaviour
{
    public GameObject bala;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(bala, transform.position, transform.rotation);
    }
}
