using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InterectPolice : MonoBehaviour
{
    public Animator ani;
    public GameObject chat;
    Quaternion first;
    public Transform player;
    bool islookplayer = false;
    private void Start()
    {
        first = transform.rotation;
        chat.SetActive(false);
    }

    private void Update()
    {
        if(islookplayer)
        {
            transform.LookAt(player);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            islookplayer = true;
            ani.SetTrigger("ThumbUp");          
            StartCoroutine(OnChatbubble());
        }
    }

    IEnumerator OnChatbubble()
    {
        chat.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        chat.SetActive(false);
        transform.rotation = first;
        islookplayer = false;
        StopCoroutine(OnChatbubble());


    }
}
