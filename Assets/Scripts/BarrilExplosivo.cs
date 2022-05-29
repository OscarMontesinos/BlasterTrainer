using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilExplosivo : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<CajaExplosiva>().Explode();
        }
    }
}
