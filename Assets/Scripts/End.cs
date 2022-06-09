using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    Timer timer;
    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.GetFloat("Minutes") == 0)
            {
                Safe();
            }
            else if (PlayerPrefs.GetFloat("Minutes") >  timer.minutes)
            {
                Safe();
            }
            else if (PlayerPrefs.GetFloat("Minutes") == timer.minutes && PlayerPrefs.GetFloat("Seconds") > timer.seconds)
            {
                Safe();
            }
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Safe()
    {
        PlayerPrefs.SetFloat("Seconds", timer.seconds);
        PlayerPrefs.SetFloat("Minutes", timer.minutes);
    }
}
