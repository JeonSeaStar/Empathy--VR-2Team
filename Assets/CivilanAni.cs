using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilanAni : MonoBehaviour
{
    public Animation[] ani;
    void Update()
    {
        if(GameManager.instance.amissionClear)
        {
            for(int i = 0; i <24; i++)
            {
                ani[i].Play();
            }
        }
    }
}
