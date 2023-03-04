using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Laptop : MonoBehaviour
{
    public MeshRenderer mr;
    public Material origin;
    public Material clear;
    public TMP_Text text;
    public SpriteRenderer Clear_Stamp;

    void Start()
    {
        Clear_Stamp.enabled = false;
        mr.materials = new Material[1] { origin };
        text.text = "\"길고양이를 피하려다 사고가?!\n" +
            "매년 증가하는 고양이 사고, 빠른 조치가 시급하다\"";
    }


    void Update()
    {
        if (GameManager.instance.bmissionClear)
        {
            Clear_Stamp.enabled = true;
            mr.materials = new Material[1] { clear };
            text.text = "\"동물들도 안전한 도시.\n" +
            "콘크리트 숲에서 자연과 공존하는 것도 불가능 아냐\"";
        }
        else
        {
            Clear_Stamp.enabled = false;
            mr.materials = new Material[1] { origin };
            text.text = "\"길고양이를 피하려다 사고가?!\n" +
            "매년 증가하는 고양이 사고, 빠른 조치가 시급하다\"";
        }
    }
}
