using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    float y;
    public float speed;
    GameObject player;
    public GameObject audioExplosion;
    public float viraje;
    public bool mirar;
    Quaternion targetRotation;
    // Start is called before the first frame update
    void Awake()
    {
        y = transform.position.y;
        player = FindObjectOfType<PlayerMovement>().gameObject;
        animator = GetComponent<Animator>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        if (mirar)
        {
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        else
        {
            targetRotation = Quaternion.LookRotation(new Vector3(player.transform.position.x + Random.Range(-viraje, viraje), player.transform.position.y, player.transform.position.z + Random.Range(-viraje, viraje)) - transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
    void Die()
    {
        Instantiate(audioExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
