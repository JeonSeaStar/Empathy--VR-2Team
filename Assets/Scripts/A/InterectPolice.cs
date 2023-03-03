using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InterectPolice : MonoBehaviour
{
    public Animator ani;
    public GameObject chat;
    Quaternion q;
    Quaternion first;
    public Transform player;
    bool islookplayer = false;
    float t = 0;
    private void Start()
    {
        first = transform.rotation;
        chat.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            t = 0;
            q = Quaternion.LookRotation(CatRotator(player.transform.position));
            //ani.SetTrigger("ThumbUp");
            islookplayer = true;
            if (islookplayer)
                ani.SetTrigger("ThumbUp");
            StartCoroutine(InterectRotate());
        }
    }

    //IEnumerator OnChatbubble()
    //{
    //    chat.SetActive(true);
    //    yield return new WaitForSecondsRealtime(3);
    //    islookplayer = false;
    //    chat.SetActive(false);
    //    //transform.rotation = Quaternion.Lerp(transform.rotation, first, t);
    //    StopCoroutine(OnChatbubble());
    //}

    Vector3 CatRotator(Vector3 destination)
    {
        return destination - transform.position;
    }

    IEnumerator InterectRotate()
    {
        t += 0.01f;
        yield return new WaitForSeconds(0.1f);
        //transform.rotation = Quaternion.Lerp(transform.rotation, q, t);
        transform.LookAt(player.transform);
        chat.SetActive(true);
        if (t < 1)
        {
            StartCoroutine(InterectRotate());
        }
        else
        {
            //chat.SetActive(true);
            yield return new WaitForSecondsRealtime(3);
            chat.SetActive(false);
            StartCoroutine(InterectRotate2());
        }
    }

    IEnumerator InterectRotate2()
    {
        t -= 0.01f;
        yield return new WaitForSeconds(0.01f);
        transform.rotation = Quaternion.Lerp(first, transform.rotation, t);
        if (t > 0)
        {
            StartCoroutine(InterectRotate2());
        }
        else
        {
            islookplayer = false;
        }
    }
}
