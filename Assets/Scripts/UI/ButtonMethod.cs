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
        //플리즈 초기화 스크립트
    }
    public void QuitGame()
    {
      Application.Quit();
    }

}
