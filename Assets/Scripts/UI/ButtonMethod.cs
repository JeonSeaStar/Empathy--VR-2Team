using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethod : MonoBehaviour
{
    public void GotoA()
    {
        SceneManager.LoadScene("A");
    }
    public void GotoB()
    {
        SceneManager.LoadScene("B");
    }
    public void GotoC()
    {
        SceneManager.LoadScene("C");
    }

    public void QuitGame()
    {
        if(UIManager.instance.isGameOff)
        {
            Application.Quit();
        }
    }

}
