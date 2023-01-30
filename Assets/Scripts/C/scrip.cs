using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrip : MonoBehaviour
{
    public List<ConMale> hehe = new List<ConMale>();
    public List<int> hihi = new List<int>();
    public List<int> huhu = new List<int>();
    public Text current_connect;

    public void haha(ConMale cm, int i)
    {
        hihi[i] = cm.num;
        kaka();
    }

    void kaka()
    {
        for(int i = 0; i < huhu.Count; i++)
        {
            if(hihi[i] == huhu[i])
            {
                if(i == huhu.Count - 1)
                {
                    Clear();
                }
            }
            else { break; }
        }
    }

    void Clear()
    {

    }
}
