using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethod : MonoBehaviour
{
    public void GotoA()
    {
        SceneManager.LoadScene(1);
    }
    public void GotoB()
    {
        SceneManager.LoadScene(2);
    }
    public void GotoC()
    {
        SceneManager.LoadScene(3);
    }

}
