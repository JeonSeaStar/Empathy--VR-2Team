using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InterectPolice : MonoBehaviour
{
    public Animator ani;
    public GameObject chat;

    private void Start()
    {
        chat.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ani.SetTrigger("ThumbUp");
            StartCoroutine(OnChatbubble());
        }
    }

    IEnumerator OnChatbubble()
    {
        chat.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        chat.SetActive(false);
        StopCoroutine(OnChatbubble());


    }
}
