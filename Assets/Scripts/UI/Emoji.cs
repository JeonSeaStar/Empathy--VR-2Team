using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emoji : MonoBehaviour
{
    public List<GameObject> emoji = new List<GameObject>();
    public bool chatNPC;

    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back, Camera.main.transform.rotation * Vector3.up);
    }

    void on_emoji()
    {
        int i = Random.Range(0, emoji.Count);
        emoji[i].SetActive(true);
    }
}
