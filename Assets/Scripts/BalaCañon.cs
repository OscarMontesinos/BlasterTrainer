using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaCañon : MonoBehaviour
{
    Vector3 startPosition;
    public float speed;
    bool start;
    float timePassed;
    public float loopTime;

    private void Awake()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        if (start)
        {
            timePassed += Time.deltaTime;
            if(timePassed >= loopTime)
            {
                transform.position = startPosition;
                timePassed = 0;
            }
            transform.Translate(Vector3.right * -speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            start = true;
        }
    }
}
