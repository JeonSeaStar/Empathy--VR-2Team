using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BubbleEvent : MonoBehaviour
{
    public float delay;

    public float delay2;
    public TextMeshProUGUI text;
    [TextArea] public string talk;
    int t = 0;

    void Awake() => text.text = "";

    void Start()
    {
        StartCoroutine(output_text());
    }
    IEnumerator output_text()
    {
        text.text += talk[t];
        yield return new WaitForSeconds(delay2);
        if (t < talk.Length - 1)
        {
            t++;
            StartCoroutine(output_text());
        }
    }
}
