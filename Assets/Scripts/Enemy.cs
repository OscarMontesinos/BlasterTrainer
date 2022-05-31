using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float y;
    // Start is called before the first frame update
    void Awake()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
