using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public GameObject box;//Ʈ���� �׾��� �ڽ� ������
    public int maxBoxnum = 20;//ġ�����ϴ� �ڽ� ��
    public int currentBoxnum = 0;//ġ�� �ڽ� ��
    public Transform[] bildingBox = new Transform[20];//ġ�� �ڽ��� ���̴� ��ġ
    bool isbildingbox = false;//�ڽ��� �״� ������

    void Start()
    {
        currentBoxnum = 0;
    }


    void Update()
    {
        InstantiateBox();
    }

    void InstantiateBox()
    {
        if (isbildingbox)
        {
            Instantiate(box, bildingBox[currentBoxnum]);
            isbildingbox = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            currentBoxnum += 1;
            isbildingbox = true;
        }
        else
        {
            other = null;
        }
    }
}
