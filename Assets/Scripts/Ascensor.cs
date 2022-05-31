using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{
    public Transform arriba;
    public Transform abajo;
    public float speed;


    public GameObject puente;
    bool bajar = true;
    public bool subir = false;
    public float toRotate;

    public IEnumerator Moverse(Transform destiny)
    {
        var dir = destiny.position - transform.position;
        while(dir.magnitude >= 0.1f)
        {
            dir = destiny.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
            yield return null;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.parent = gameObject.transform;
        }
        if (bajar)
        {
            bajar = false;
            StartCoroutine(Moverse(abajo));
        }
        if (subir)
        {
            StartCoroutine(gg());
        }
       
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
    IEnumerator gg()
    {
        subir = false;
        StartCoroutine(Moverse(arriba));
        yield return Moverse(arriba);
        StartCoroutine(rotar());
    }
    IEnumerator rotar()
    {
        puente.transform.parent = gameObject.transform;
        while (toRotate > 0)
        {
            toRotate -= speed * 3 * Time.deltaTime;
            transform.eulerAngles += new Vector3(0, speed*3 * Time.deltaTime, 0);
            yield return null;
        }
    }
}
