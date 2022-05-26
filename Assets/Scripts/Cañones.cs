using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañones : MonoBehaviour
{

    public bool inverse;
    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f);
        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            transform.LookAt(hit.point);
        }
    }
}
