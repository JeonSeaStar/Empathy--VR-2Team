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
    public GameObject Clear_Stamp;

    void Start()
    {
        Clear_Stamp.SetActive(false);
        mr.materials = new Material[1] { origin };
        text.text = "\"�����̸� ���Ϸ��� ���?!\n" +
            "�ų� �����ϴ� ����� ���,\n���� ��ġ�� �ñ��ϴ�\"";
    }


    void Update()
    {
        if (GameManager.instance.bmissionClear)
        {
            Clear_Stamp.SetActive(true);
            mr.materials = new Material[1] { clear };
            text.text = "\"�����鵵 ������ ����.\n" +
            "��ũ��Ʈ ������ �ڿ��� �����ϴ� �͵�\n�Ұ��� �Ƴ�\"";
        }
        else
        {
            Clear_Stamp.SetActive(false);
            mr.materials = new Material[1] { origin };
            text.text = "\"�����̸� ���Ϸ��� ���?!\n" +
            "�ų� �����ϴ� ����� ���,\n���� ��ġ�� �ñ��ϴ�\"";
        }
    }
}
