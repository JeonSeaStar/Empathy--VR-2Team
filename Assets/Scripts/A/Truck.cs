using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public int maxBoxnum = 20;//ġ�����ϴ� �ڽ� ��
    public int currentBoxnum = -1;//ġ�� �ڽ� ��
    public GameObject[] bildingBox = new GameObject[20];//ġ�� �ڽ��� ���̴� ��ġ

    void Start()
    {
        currentBoxnum = 0;
    }

    void Update()
    {
        OnBox();
    }

    void OnBox()
    {
        bildingBox[currentBoxnum].SetActive(true);
        GameManager.instance.currentBoxNum = currentBoxnum;
        if(currentBoxnum == maxBoxnum)
        {
            GameManager.instance.missionClear = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Box") && currentBoxnum < 21)
        {
            currentBoxnum += 1;
            Destroy(other.gameObject);
        }
    }
}
