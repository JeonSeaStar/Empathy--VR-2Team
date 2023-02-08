using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilanAni : MonoBehaviour
{
    public Animator[] anis = new Animator[24];

    void Start()
    {
        for (int i = 0; i < 24; i++)
        {
            anis[i].enabled = true;
        }
    }

    
    void Update()
    {
        if(GameManager.instance.amissionClear)
        {
            for(int i =0; i <24; i++)
            {
                anis[i].SetTrigger("Clear");
            }
        }
    }
}
