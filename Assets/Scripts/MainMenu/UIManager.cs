using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("LevelDesign");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
