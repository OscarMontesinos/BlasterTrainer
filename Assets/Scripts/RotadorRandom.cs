using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotadorRandom : MonoBehaviour
{
    public float speed;
    public float seconds;
    public float minTime;
    public float maxTime;
    bool dentro = true;
    public Luz luz;
    // Start is called before the first frame update
    void Awake()
    {
        seconds = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        seconds -= Time.deltaTime;
        if(seconds <= 1.5f)
        {
            luz.ChangeState(true);
        }
        if (seconds <= 0 && dentro)
        {
            dentro = false;
            if (speed < 0)
            {
                StartCoroutine(Cambio(false));
            }
            else
            {
                StartCoroutine(Cambio(true));
            }
            seconds = Random.Range(minTime, maxTime);
        }
        transform.eulerAngles += new Vector3(0, speed * Time.deltaTime, 0);
    }

    IEnumerator Cambio(bool positivo)
    {
        
        float destino = -speed;
        while (speed != destino)
        {
            if (positivo)
            {
                speed -= 5;
            }
            else
            {

                speed += 5;
            }
            yield return null;
        }
        luz.ChangeState(false);
        dentro = true;
    }
}
