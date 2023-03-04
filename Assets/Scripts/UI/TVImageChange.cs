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
        text.text = "��� ���� �ҽ� �Դϴ�, \n" +
            "��Ÿ����� ���� ������ �̲������鼭 \n" +
            "���� ȥ���� ��ȭ�ǰ� �ֽ��ϴ�.";
    }


    void Update()
    {
        if (GameManager.instance.amissionClear)
        {
            Clear_Stamp.enabled = true;
            mr.materials = new Material[2] { high, clear };
            text.text = "��� ���� �ҽ� �Դϴ�, \n" +
                "��Ÿ� ������ �����Ǹ鼭 \n" +
                "���� ȥ���� ������ �ؼҵǰ� �ֽ��ϴ�.\n";
        }
        else
        {
            Clear_Stamp.enabled = false;
            mr.materials = new Material[2] { high, origin };
            text.text = "��� ���� �ҽ� �Դϴ�, \n" +
                "��Ÿ����� ���� ������ �̲������鼭 \n" +
                "���� ȥ���� ��ȭ�ǰ� �ֽ��ϴ�.\n";
        }
    }
}
