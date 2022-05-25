using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eND : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
