using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float seconds;
    public float minutes;

    private void Update()
    {
        seconds += Time.deltaTime;
        if(seconds >= 60)
        {
            seconds -= 60;
            minutes += 1;
        }
    }
}
