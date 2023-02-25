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

    void Start()
    {
        mr.materials = new Material[1] { origin };
        text.text = "\"�����̸� ���Ϸ��� ���?!\n" +
            "�ų� �����ϴ� ����� ���, ���� ��ġ�� �ñ��ϴ�\"";
    }


    void Update()
    {
        if (GameManager.instance.bmissionClear)
        {
            mr.materials = new Material[1] { clear };
            text.text = "\"�����鵵 ������ ����.\n" +
            "��ũ��Ʈ ������ �ڿ��� �����ϴ� �͵� �Ұ��� �Ƴ�\"";
        }
        else
        {
            mr.materials = new Material[1] { origin };
            text.text = "\"�����̸� ���Ϸ��� ���?!\n" +
            "�ų� �����ϴ� ����� ���, ���� ��ġ�� �ñ��ϴ�\"";
        }
    }
}
