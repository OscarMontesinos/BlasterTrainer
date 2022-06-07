using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFinal : MonoBehaviour
{
    public float speed;
    public Transform origen;
    public Transform destino;
    bool go;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            go = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            go = false;
        }
    }
    private void Update()
    {
        var dir = transform.position;
        if (!go)
        {
            dir = origen.position - transform.position;
        }
        else
        {
            dir = destino.position - transform.position;
        }
        if (dir.magnitude > 2)
        {
            transform.Translate(dir.normalized * speed * Time.deltaTime);
        }
    }
}
