using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    PlayerMovement player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "object")
        {
            player.jumpable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "object")
        {
            player.jumpable = false;
        }
    }
}
