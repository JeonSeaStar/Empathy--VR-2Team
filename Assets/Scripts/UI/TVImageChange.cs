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
    public GameObject Clear_Stamp;

    void Start()
    {
        Clear_Stamp.SetActive(false);
        mr.materials = new Material[2] {high,origin };
        text.text = "��� ���� �ҽ� �Դϴ�, \n" +
            "��Ÿ����� ���� ������ �̲������鼭 \n" +
            "���� ȥ���� ��ȭ�ǰ� �ֽ��ϴ�.";
    }


    void Update()
    {
        if (GameManager.instance.amissionClear)
        {
            Clear_Stamp.SetActive(true);
            mr.materials = new Material[2] { high, clear };
            text.text = "��� ���� �ҽ� �Դϴ�, \n" +
                "��Ÿ� ������ �����Ǹ鼭 \n" +
                "���� ȥ���� ������ �ؼҵǰ� �ֽ��ϴ�.\n";
        }
        else
        {
            Clear_Stamp.SetActive(false);
            mr.materials = new Material[2] { high, origin };
            text.text = "��� ���� �ҽ� �Դϴ�, \n" +
                "��Ÿ����� ���� ������ �̲������鼭 \n" +
                "���� ȥ���� ��ȭ�ǰ� �ֽ��ϴ�.\n";
        }
    }
}
