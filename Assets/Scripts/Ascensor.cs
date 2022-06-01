using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{
    public Transform arriba;
    public Transform abajo;
    public float speed;
    bool moviendo;

    public GameObject puente;
    bool bajar = true;
    public bool subir = false;
    public float toRotate;

    public IEnumerator Moverse(Transform destiny)
    {
        moviendo = true;
        yield return new WaitForSeconds(0.1f);
        var dir = destiny.position - transform.position;
        while(dir.magnitude >= 0.1f)
        {
            dir = destiny.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
            yield return null;
        }
        moviendo = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.parent = gameObject.transform;
            if (bajar && !moviendo)
            {
                bajar = false;
                StartCoroutine(Moverse(abajo));
            }
            if (subir && !moviendo)
            {
                StartCoroutine(gg());
            }
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
        while (true)
        {
            transform.eulerAngles += new Vector3(0, speed * Time.deltaTime, 0);
            yield return null;
        }
    }
}
