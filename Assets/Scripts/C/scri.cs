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

    private void Awake()
    {
        col = GetComponent<BoxCollider>();
    }

    void colonoff()
    {
        if (connect) { col.enabled = false; }
        else { col.enabled = true; }
    }
}
