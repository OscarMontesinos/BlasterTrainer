using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZamburguesaTrampa : MonoBehaviour
{
    bool now;
    public float speed;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            now = true;
        }
    }

    private void Update()
    {
        if (now)
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
        }
    }
}
