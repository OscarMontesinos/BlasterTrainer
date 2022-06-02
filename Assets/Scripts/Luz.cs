using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    public bool on;
    public Material iluminado;
    public Material apagado;
    public GameObject luzGo;
    public float time;
    float count;
    bool lighted;

    private void Update()
    {
        if (on)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                lighted = !lighted;
                count = time;
            }

            if (lighted)
            {
                luzGo.SetActive(true);
                transform.GetChild(0).GetComponent<MeshRenderer>().material = iluminado;
            }
            else
            {

                luzGo.SetActive(false);
                transform.GetChild(0).GetComponent<MeshRenderer>().material = apagado;
            }
        }
    }
    public void ChangeState(bool state)
    {
        on = state;
        if (!on)
        {
            lighted = false;
            count = time;
        }
    }

}
