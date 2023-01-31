using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emoji : MonoBehaviour
{
    public List<GameObject> emoji = new List<GameObject>();
    public GameObject Bubble;
    public bool chatNPC;

    void Awake()
    {
        if(!chatNPC)
        {
            int i = Random.Range(0, emoji.Count);
            emoji[i].SetActive(true);
        }
        if(chatNPC)
        {
            Bubble.SetActive(true);
        }
    }
}
