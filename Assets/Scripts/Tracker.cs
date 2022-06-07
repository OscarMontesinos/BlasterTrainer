using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public Material encendidoMat;
    public Material apagadoMat;
    public Material avisandoMat;
    bool encendido;
    public GameObject bala;
    public float minTime;
    public float maxTime;
    public float rechargeTime;
    float actualRechargeTime;
    public float tiempoTrans;
    private void Awake()
    {
        tiempoTrans = Random.Range(minTime, maxTime);
    }
    private void Update()
    {
        transform.LookAt(FindObjectOfType<PlayerMovement>().gameObject.transform);
        if (actualRechargeTime > 0)
        {
            actualRechargeTime -= Time.deltaTime;
        }
        tiempoTrans -= Time.deltaTime;
        if(tiempoTrans < 1 && !encendido)
        {
            transform.GetChild(1).GetComponent<MeshRenderer>().material = avisandoMat;
        }
        if (tiempoTrans <0)
        {
            
            encendido = !encendido;
            if (encendido)
            {
                transform.GetChild(1).GetComponent<MeshRenderer>().material = encendidoMat;
                tiempoTrans = 2;
            }
            else
            {
                transform.GetChild(1).GetComponent<MeshRenderer>().material = apagadoMat; 
                tiempoTrans = Random.Range(minTime, maxTime);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetMouseButton(0))
            {
                if (actualRechargeTime <= 0)
                {
                    Shoot();
                }
            }
            if (encendido || tiempoTrans < 1)
            {
                GetComponent<LineRenderer>().enabled = true;
                Vector3[] array = new Vector3[2];
                array[0] = transform.position;
                array[1] = other.transform.position;
                GetComponent<LineRenderer>().SetPositions(array);
            }
            else
            {

                GetComponent<LineRenderer>().enabled = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
            GetComponent<LineRenderer>().enabled = false;
    }
    void Shoot()
    {
        actualRechargeTime = rechargeTime;
        if (encendido)
        {
            Instantiate(bala, transform.position, transform.rotation);
        }
    }
}
