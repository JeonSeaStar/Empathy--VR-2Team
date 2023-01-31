using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIO : MonoBehaviour
{
    public Animator anime;
    public CClear cc;
    [HideInInspector] public int hash = Animator.StringToHash("IO");

    void Start()
    {
        anime.SetTrigger(hash);
    }

    public void Clear_Event_Setting()
    {
        cc.clear_setting();
    }

    public void Clear()
    {
        cc.clear_ani();
    }
}
