using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethod : MonoBehaviour
{
    public void GotoRoom()
    {
        LodingSceneManager.LoadScene("Room");
    }
    public void GotoA()
    {
        LodingSceneManager.LoadScene("A");
    }
    public void GotoB()
    {
        LodingSceneManager.LoadScene("B");
    }
    public void GotoC()
    {
        LodingSceneManager.LoadScene("C");
    }
    public void Reset()
    {
        //�ø��� �ʱ�ȭ ��ũ��Ʈ
    }
    public void QuitGame()
    {
      Application.Quit();
    }

}
