using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSala4 : MonoBehaviour
{
    Enemy enemy;
    bool done;
    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }
    private void Update()
    {
        if (enemy == null && !done)
        {
            Actualizar();
        }
    }
    void Actualizar()
    {
        enemy = FindObjectOfType<Enemy>();
        if (enemy == null)
        {
            done = true;
            FindObjectOfType<Ascensor>().subir = true;
        }
    }
}
