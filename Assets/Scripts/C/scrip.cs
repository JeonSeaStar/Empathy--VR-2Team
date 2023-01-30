using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrip : MonoBehaviour
{
    public Text current_connect_text;
    public int current_connect
    {
        get { return current_connect; }
        set
        {
            current_connect = value;
            current_connect_text.text = current_connect.ToString();
            if (current_connect == 0)
                Clear();
        }
    }
    public JeonSeon[] js = new JeonSeon[4];
    public bool clear;

    void Clear()
    {
        clear = true;
    }
}
