using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadSceneGame()
    {
        SceneManager.LoadScene("LevelDesign");
    }
     public void LoadSceneOptions()
        {
            SceneManager.LoadScene("Options");
        }
     
     public void LoadSceneControles()
     {
         SceneManager.LoadScene("Controles");
     }
     
     public void LoadSceneMenu()
     {
         SceneManager.LoadScene("MainMenu");
     }

    public void Exit()
    {
        Application.Quit();
    }
}
