using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public Timer timer;
    bool isuiOn = false;
 
    void Update()
    {
        OnMenu();      
    }

    void OnMenu()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B)&& !isuiOn)
        {
            if(SceneManager.GetActiveScene().buildIndex !=5 && 
                SceneManager.GetActiveScene().buildIndex != 0 && 
                SceneManager.GetActiveScene().buildIndex != 1)
            {
                timer.StopTimer();
                isuiOn = true;
                menu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void OffMenu()
    {
        StartCoroutine(timer.TimerCorutine());
        isuiOn = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void GotoRoom()
    {
        LodingSceneManager.LoadScene("Room", "Non");
        isuiOn = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
