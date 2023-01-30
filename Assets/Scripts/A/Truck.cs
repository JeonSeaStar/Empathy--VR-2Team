using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public int maxBoxnum = 20;// MAX �ڽ� ��
    public int currentBoxnum = 0;//ġ�� �ڽ� ��
    public GameObject[] bildingBox = new GameObject[20];//ġ�� �ڽ��� ���̴� ��ġ

    void Update()
    {
        OnBox();
    }

    void OnBox()
    {
        GameManager.instance.currentBoxNum = currentBoxnum;
        if(currentBoxnum >= 1)
        {
            bildingBox[currentBoxnum - 1].SetActive(true);
            if(currentBoxnum >= 2)
            {
                if (bildingBox[currentBoxnum - 2].activeSelf != true)
                {
                    bildingBox[currentBoxnum - 2].SetActive(true);
                }
            }
        }
        if (currentBoxnum == maxBoxnum)
        {
            GameManager.instance.amissionClear = true;
            for(int i =0; i<20;i++)
            {
                if(bildingBox[i].activeSelf != true)
                {
                    bildingBox[i].SetActive(true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box") && currentBoxnum < 21)
        {
            currentBoxnum += 1;
            Destroy(other.gameObject);
        }
    }
}
