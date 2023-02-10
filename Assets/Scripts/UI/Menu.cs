using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    bool isuiOn = false;
 
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            isuiOn = true;
            menu.SetActive(true);
            Time.timeScale = 0;
            //if (OVRInput.GetDown(OVRInput.RawButton.Start))
            //{
            //    isuiOn = false;
            //    menu.SetActive(false);
            //    Time.timeScale = 1;
            //    Debug.Log("¾ÈµÅ?");
            //}
        }
    }
    public void OffMenu()
    {
        isuiOn = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
