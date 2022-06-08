using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{

    public void ChangeBright()
    {
        GetComponent<Image>().color = new Color32(0,0,0, (byte)(FindObjectOfType<Slider>().value*255));
    }
}
