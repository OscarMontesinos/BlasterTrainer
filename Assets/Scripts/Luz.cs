using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    public Material iluminado;
    public Material apagado;
    public GameObject luzGo;
    public float time;
    float count;
    bool lighted;

    private void Update()
    {
        count -= Time.deltaTime;
        if(count <= 0)
        {
            lighted = !lighted;
            count = time;
        }

        if (lighted)
        {
            luzGo.SetActive(true);
            GetComponent<MeshRenderer>().material = iluminado;
        }
        else
        {

            luzGo.SetActive(false);
            GetComponent<MeshRenderer>().material = apagado;
        }
    }

}
