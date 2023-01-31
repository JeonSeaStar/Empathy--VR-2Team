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

    public void ChangePosition()
    {
        UIManager.instance.player.transform.position = UIManager.instance.aClearTransform.position;
        UIManager.instance.player.transform.rotation = UIManager.instance.aClearTransform.rotation;
    }
}
