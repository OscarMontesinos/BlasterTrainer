using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    public Text recordT;
    private void Update()
    {
        recordT.text = "Record " + PlayerPrefs.GetFloat("Minutes") + " : " + PlayerPrefs.GetFloat("Minutes").ToString("P0");
    }
}
