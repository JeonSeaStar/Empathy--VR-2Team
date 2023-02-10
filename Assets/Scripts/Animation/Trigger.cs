using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Trigger : MonoBehaviour
{
    public AudioSource audioSource;

    public void StartCheering()
    {
        audioSource.Play();
    }

    public void FadeIn()
    {
        UIManager.instance.fadeAni.SetTrigger("FadeIn");
    }

    public void GoBackRoom()
    {
        UIManager.instance.playercc.enabled = true;
        GameManager.instance.aMissionReset = true;
        LodingSceneManager.LoadScene("Room","Non");
    }

    public void ChangePosition()
    {
        UIManager.instance.player.transform.position = UIManager.instance.aClearTransform.position;
        UIManager.instance.player.transform.rotation = UIManager.instance.aClearTransform.rotation;
    }

    public float delay;
    public TMP_Text text;
    [TextArea] public string talk;
    int t = 0;

    IEnumerator output_text()
    {
        text.text += talk[t];
        yield return new WaitForSeconds(delay);
        if (t < talk.Length - 1)
        {
            t++;
            StartCoroutine(output_text());
        }
    }

    public void OutputText()
    {
        StartCoroutine(output_text());
    }
}
