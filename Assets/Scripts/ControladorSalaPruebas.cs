using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorSalaPruebas : MonoBehaviour
{
    public void Volver()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
