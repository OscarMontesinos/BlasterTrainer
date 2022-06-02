using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemies;
    Ascensor ascensor;

    private void Awake()
    {
        ascensor = FindObjectOfType<Ascensor>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !ascensor.subir)
        {
            Instantiate(enemies,transform.position,transform.rotation);
        }
    }
}
