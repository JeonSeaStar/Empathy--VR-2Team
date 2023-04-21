using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocketChecker : MonoBehaviour
{
    public Text current_connect_text;
    public int _current_connect;
    public int current_connect
    {
        get { return _current_connect; }
        set
        {
            _current_connect = value;
            current_connect_text.text = current_connect.ToString();
            if (current_connect == 4)
                StartCoroutine(Clear());
        }
    }
    public Cable[] js = new Cable[4];
    public bool clear;
    public FadeIO fade;

    void Update()
    {
        //if(clear && current_connect != 4)
        //{
        //    StopAllCoroutines();
        //    clear = false;
        //}


        if (Input.GetKeyDown(KeyCode.C)) { StartCoroutine(Clear()); }
    }

    IEnumerator Clear()
    {
        clear = true;
        yield return new WaitForSeconds(2f);
        fade.anime.SetTrigger(fade.hash);
        StartCoroutine(fade.SceneLoad());
    }
}
