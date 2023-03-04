using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TVImageChange : MonoBehaviour
{
    public MeshRenderer mr;
    public Material high;
    public Material origin;
    public Material clear;
    public TMP_Text text;
    public SpriteRenderer Clear_Stamp;

    void Start()
    {
        Clear_Stamp.enabled = false;
        mr.materials = new Material[2] {high,origin };
        text.text = "방금 들어온 소식 입니다, \n" +
            "사거리에서 과적 차량이 미끄러지면서 \n" +
            "교통 혼잡이 심화되고 있습니다.";
    }


    void Update()
    {
        if (GameManager.instance.amissionClear)
        {
            Clear_Stamp.enabled = true;
            mr.materials = new Material[2] { high, clear };
            text.text = "방금 들어온 소식 입니다, \n" +
                "사거리 현장이 정리되면서 \n" +
                "교통 혼잡이 빠르게 해소되고 있습니다.\n";
        }
        else
        {
            Clear_Stamp.enabled = false;
            mr.materials = new Material[2] { high, origin };
            text.text = "방금 들어온 소식 입니다, \n" +
                "사거리에서 과적 차량이 미끄러지면서 \n" +
                "교통 혼잡이 심화되고 있습니다.\n";
        }
    }
}
