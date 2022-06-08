using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float seconds;
    public float minutes;
    public Text contador;
    private void Update()
    {
        seconds += Time.deltaTime;
        if(seconds >= 60)
        {
            seconds -= 60;
            minutes += 1;
        }
        contador.text = minutes + " : " + seconds.ToString("F0");
    }
}
