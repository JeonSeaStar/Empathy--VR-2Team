using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public int time;
    public int currentTime;
    public int Time
    {
        get { return currentTime; }
        set
        {
            currentTime = value;
            min.text = (currentTime / 60).ToString();
            sec.text = (currentTime % 60).ToString();
        }
    }
    public Text min;
    public Text sec;
    public Animator fade;

    void Start()
    {
        Time = time;
        StartCoroutine(TimerCorutine());
    }

    IEnumerator TimerCorutine()
    {
        yield return new WaitForSecondsRealtime(1);
        if (Time > 0)
        {
            Time -= 1;
            StartCoroutine(TimerCorutine());
            //text.text = time.ToString();
        }
        else if (Time <= 0)
        {
            Trigger();
        }
    }

    private void Trigger()
    {
        fade.SetTrigger("FailedFadeIn");
    }
}
