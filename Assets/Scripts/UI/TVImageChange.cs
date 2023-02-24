using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVImageChange : MonoBehaviour
{
    public MeshRenderer mr;
    public Material origin;
    public Material clear;

    void Start()
    {
        mr.materials[1] = origin;
    }

    
    void Update()
    {
        if(GameManager.instance.amissionClear)
        {
            mr.materials[1] = clear;
        }
        else
        {
            mr.materials[1] = origin;
        }
    }
}
