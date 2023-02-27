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
            min.text = (currentTime / 60).ToString("D2");
            sec.text = (currentTime % 60).ToString("D2");
        }
    }
    public Text min;
    public Text sec;
    public Animator fade;
    public Image timerImage;
    public Sprite fireTimer;
    public Animation anime;
    public AudioSource audi;

    void Start()
    {
        Time = time;
        StartCoroutine(TimerCorutine());
    }

    public IEnumerator TimerCorutine()
    {
        yield return new WaitForSecondsRealtime(1);
        if (Time > 0)
        {
            Time -= 1;
            if (Time == 30) { TimeLeft(); }
            StartCoroutine(TimerCorutine());
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

    void TimeLeft()
    {
        timerImage.sprite = fireTimer;
        anime.Play();
        audi.PlayOneShot(audi.clip);
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }
}
