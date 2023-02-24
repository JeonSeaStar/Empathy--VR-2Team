using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public void FadeIn()
    {
        this.GetComponent<Animator>().SetTrigger("FadeIn");
    }
    public void FadeOut()
    {
        this.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void GoBackRoom()
    {
        UIManager.instance.playercc.enabled = true;
        LodingSceneManager.LoadScene("Room", "Non");
    }

    public void ChangePosition()
    {
        UIManager.instance.player.transform.position = UIManager.instance.aClearTransform.position;
        UIManager.instance.player.transform.rotation = UIManager.instance.aClearTransform.rotation;
    }
}
