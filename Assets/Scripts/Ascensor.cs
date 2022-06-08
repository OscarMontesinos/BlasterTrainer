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
    public bool bajar = true;
    public bool subir = false;
    public float toRotate;
    public Luz luz1;
    public Luz luz2;

    public IEnumerator Moverse(Transform destiny)
    {
        GetComponent<AudioSource>().Play();
        luz1.ChangeState(true);
        luz2.ChangeState(true);
        moviendo = true;
        yield return new WaitForSeconds(0.1f);
        var dir = destiny.position - transform.position;
        while(dir.magnitude >= 0.1f)
        {
            dir = destiny.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
            yield return null;
        }
        luz1.ChangeState(false);
        luz2.ChangeState(false);
        moviendo = false;
        GetComponent<AudioSource>().Stop();
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
        GetComponent<AudioSource>().Play();
        puente.transform.parent = gameObject.transform;
        while (true)
        {
            transform.eulerAngles += new Vector3(0, speed * Time.deltaTime, 0);
            yield return null;
        }
    }
}
