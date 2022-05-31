using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float y;
    public float speed;
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        y = transform.position.y;
        player = FindObjectOfType<PlayerMovement>().gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = player.transform.position - transform.position;

    }
}
