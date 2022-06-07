using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchilla : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    bool pos2B;
    public float speed;
    public float seconds;


    private void Awake()
    {
        StartCoroutine(Behaviour());
    }

    IEnumerator Behaviour()
    {
        Vector3 dir = new Vector3(1,1,1);
        
        while (dir.magnitude > 0.5f)
        {
            
            if (pos2B) { dir = pos2.position - transform.position; }
            else { dir = pos1.position - transform.position; }
           
            transform.Translate(dir.normalized * speed * Time.deltaTime);
            yield return null;
        }
        pos2B = !pos2B;
        yield return new WaitForSeconds(seconds);
        StartCoroutine(Behaviour());
    }
}
