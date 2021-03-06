using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamadorAscensor : MonoBehaviour
{
    Ascensor ascensor;
    bool done;
    private void Awake()
    {
        ascensor = FindObjectOfType<Ascensor>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ascensor.StartCoroutine(ascensor.Moverse(ascensor.arriba));
            ascensor.bajar = true;
        }
    }
    
}
