using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenSecond : MonoBehaviour
{
    public ButtonMethod buttonMethod;
    int second = 10;
    void Start()
    {
        StartCoroutine(TenSeconds());
    }
    IEnumerator TenSeconds()
    {
        yield return new WaitForSecondsRealtime(10);
        buttonMethod.FirstStartGotoRoom();
        StopCoroutine(TenSeconds());
    }
}
