using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethod : MonoBehaviour
{
    public void FirstStartGotoRoom()
    {
        LodingSceneManager.LoadScene("Room", "s");
    }
    public void GotoRoom()
    {
        LodingSceneManager.LoadScene("Room","Non");
    }
    public void GotoA()
    {
        LodingSceneManager.LoadScene("A","a");
    }
    public void GotoB()
    {
        LodingSceneManager.LoadScene("B","b");
    }
    public void GotoC()
    {
        LodingSceneManager.LoadScene("C","c");
    }
    public void Reset()
    {
        if (GameManager.instance.amissionClear)
        {
            GameManager.instance.amissionClear = false;
        }
        else if(GameManager.instance.bmissionClear)
        {
            GameManager.instance.bmissionClear = false;
        }
        else if(GameManager.instance.cmissionClear)
        {
            GameManager.instance.cmissionClear = false;
        }
    }
    public void QuitGame()
    {
      Application.Quit();
    }

}
