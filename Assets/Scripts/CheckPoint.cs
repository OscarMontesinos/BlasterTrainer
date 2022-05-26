using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameObject player;
    public float respawnTime;
    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().checkpoint = gameObject;
        }
    }
    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        player.SetActive(true);
        FindObjectOfType<CameraPlayer>().seguir = true;
    }
}
