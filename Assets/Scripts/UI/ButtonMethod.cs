using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethod : MonoBehaviour
{
    public GameObject cleared;

    public void FirstStartGotoRoom()
    {
        LodingSceneManager.LoadScene("Room", "s");
    }
    public void GotoRoom()
    {
        LodingSceneManager.LoadScene("Room", "Non");
    }
    public void GotoA()
    {
        if (!GameManager.instance.amissionClear)
        {
            LodingSceneManager.LoadScene("A", "a");
        }
        if (GameManager.instance.amissionClear && cleared != null)
        {
            cleared.SetActive(true);
        }
    }
    public void GotoB()
    {
        if (!GameManager.instance.bmissionClear)
        {
            LodingSceneManager.LoadScene("B", "b");
        }
        if (GameManager.instance.bmissionClear && cleared != null)
        {
            cleared.SetActive(true);
        }
    }
    public void GotoC()
    {
        if (!GameManager.instance.cmissionClear)
        {
            LodingSceneManager.LoadScene("C", "c");
        }
        if (GameManager.instance.cmissionClear && cleared != null)
        {
            cleared.SetActive(true);
        }
    }

    public void GotoRoomAndReset()
    {
        LodingSceneManager.LoadScene("Room", "Non");
        ResetMission();
    }
    public void ResetMission()
    {
        if (GameManager.instance.amissionClear)
        {
            GameManager.instance.amissionClear = false;
        }
        if (GameManager.instance.bmissionClear)
        {
            GameManager.instance.bmissionClear = false;
        }
        if (GameManager.instance.cmissionClear)
        {
            GameManager.instance.cmissionClear = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
