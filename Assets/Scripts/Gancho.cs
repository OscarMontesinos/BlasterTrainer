using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gancho : MonoBehaviour
{
    bool gancheable = true;
    bool avanzando;
    public bool enganchado;
    public float speed = 0;
    public float range = 0;
    float path = 0;
    public GameObject point;
    public GameObject robot;
    public LayerMask ganchoLayer;

    public virtual void Awake()
    {
    
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && gancheable)
        {
            gancheable = false;
            avanzando = true;
            StartCoroutine(Avance());
        }
        if (Input.GetMouseButtonUp(1)) 
        {
            if (!gancheable)
            {
                avanzando = false;
                enganchado = false;
                StartCoroutine(Volver());
            }
        }
       
        if(Input.GetKeyDown(KeyCode.Space) && enganchado)
        {
            avanzando = false;
            enganchado = false;
            StartCoroutine(Volver());
            robot.GetComponent<PlayerMovement>().GanchoSalto();
        }
    }
    private void FixedUpdate()
    {
        if (enganchado)
        {
            robot.GetComponent<Rigidbody>().useGravity = false;
            var dist = transform.position - robot.transform.position;
            robot.GetComponent<PlayerMovement>()._rigidbody.AddForce(dist.normalized * robot.GetComponent<PlayerMovement>().hookTractionSpeed, ForceMode.Force);
        }
    }



    public virtual IEnumerator Avance()
    {
        path = 0;
        transform.parent = null; 
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f);
        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
        transform.rotation = robot.transform.rotation;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range,ganchoLayer))
        {
            transform.LookAt(hit.point);
        }
        while (range >= path && avanzando && !enganchado)
        {

           transform.Translate( Vector3.forward * speed*  Time.deltaTime);
            path += speed * Time.deltaTime;
            
            yield return new WaitForSeconds(0.0001f);

        }
        avanzando = false;
        if(!avanzando && !enganchado)
        {
            StartCoroutine(Volver());
        }
    }
    public virtual IEnumerator Volver()
    {
        transform.parent = null;
        robot.GetComponent<Rigidbody>().useGravity = true;
        var dist = point.transform.position - transform.position;
        while (dist.magnitude > 0.5)
        {
            dist = point.transform.position - transform.position;
            //transform.Translate(dist.normalized * speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, point.transform.position, speed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);

        }
        gancheable = true;
        transform.position = point.transform.position;
        transform.parent = point.transform;
        transform.rotation= robot.transform.rotation;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gancheable" && avanzando)
        {
            enganchado = true;
            transform.parent = other.gameObject.transform;
        }
    }
}
