using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    Maniqui maniqui;
    bool done;
    public GameObject destination;
    public float speed;
    private void Awake()
    {
        maniqui = FindObjectOfType<Maniqui>();
    }
    private void Update()
    {
        if (maniqui==null && !done)
        {
            Actualizar();
        }
    }
    void Actualizar()
    {
        maniqui = FindObjectOfType<Maniqui>();
        if (maniqui == null)
        {
            done = true;
            StartCoroutine(open());
        }
    }
    IEnumerator open()
    {
        var dist = destination.transform.position - transform.position;
        while (dist.magnitude >0.5f)
        {
            transform.Translate(dist * speed * Time.deltaTime);
            dist = destination.transform.position - transform.position;
            yield return null;
        }
    }
}
