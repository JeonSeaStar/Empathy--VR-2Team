using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public void FadeIn()
    {
        UIManager.instance.fadeAni.SetTrigger("FadeIn");
    }

    public void GoBackRoom()
    {
        GameManager.instance.aMissionReset = true;
        LodingSceneManager.LoadScene("Room");
    }
}
