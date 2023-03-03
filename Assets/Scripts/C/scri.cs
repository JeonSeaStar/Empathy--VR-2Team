using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scri : MonoBehaviour
{
    public int h;
    public bool _connect;
    public bool connect
    {
        get { return _connect; }
        set
        {
            _connect = value;
            colonoff();
        }
    }
    public BoxCollider col;
    public AudioSource ads;
    public Transform t;
    public Animation guideAni;

    private void Awake()
    {
        col = GetComponent<BoxCollider>();
    }

    void colonoff()
    {
        if (connect)
        {
            col.enabled = false;
            ads.mute = true;
            guideAni.gameObject.SetActive(false);
        }
        else if(!connect)
        {
            col.enabled = true;
            ads.mute = false;
            guideAni.gameObject.SetActive(true);
        }
    }
}
