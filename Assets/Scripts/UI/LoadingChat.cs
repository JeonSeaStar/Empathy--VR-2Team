using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingChat : MonoBehaviour
{
    public float delay;
    public TMP_Text text;
    [TextArea] public string talk;
    int t = 0;

    void Start()
    {
        StartCoroutine(output_text());
    }
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
}
