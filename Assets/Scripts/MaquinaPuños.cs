using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaPuños : MonoBehaviour
{
     float timeLoop;
    public float maxTime;
    public float minTime;
    public float speed;
    public bool inverse;
    bool go = true;
    float target2 = -0.1132603f;
    float target1 = -0.3685f;
    GameObject puño;
    bool ready = true;
    private void Awake()
    {
        timeLoop = Random.Range(minTime, maxTime);
        puño = transform.GetChild(0).gameObject;
        if (inverse)
        {
            go = false;
            puño.transform.localPosition = new Vector3(puño.transform.localPosition.x, puño.transform.localPosition.y, target1);
        }

    }
    // Update is called once per frame
    void Update()
    {
        timeLoop -= Time.deltaTime;
        if(timeLoop <= 0 && ready)
        {
            ready = false;
            Accion();
        }
    }
    void Accion()
    {

        if (go)
        {
            go = false;
            StartCoroutine(Maquinaria(target1));
        }
        else
        {
            go = true;
            StartCoroutine(Maquinaria(target2));
        }

    }
    IEnumerator Maquinaria(float destiny)
    {
        if (destiny == target1) 
        {
            while (puño.transform.localPosition.z >= target1)
            {
                puño.transform.localPosition = new Vector3(puño.transform.localPosition.x , puño.transform.localPosition.y, puño.transform.localPosition.z - speed * Time.deltaTime);
                yield return null;
            }
            timeLoop = Random.Range(minTime, maxTime);
        }
        else
        {
            while (puño.transform.localPosition.z <= target2)
            {
                puño.transform.localPosition = new Vector3(puño.transform.localPosition.x, puño.transform.localPosition.y, puño.transform.localPosition.z + speed * Time.deltaTime);
                yield return null;
            }
            timeLoop = Random.Range(minTime, maxTime);
        }
        ready = true;
    }
}
