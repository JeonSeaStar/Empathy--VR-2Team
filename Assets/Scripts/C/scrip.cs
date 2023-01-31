using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrip : MonoBehaviour
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
            if (current_connect == 0)
                Clear();
        }
    }
    public JeonSeon[] js = new JeonSeon[4];
    public bool clear;
    public FadeIO fade;

    void Clear()
    {
        clear = true;
        fade.anime.SetTrigger(fade.hash);
    }
}
