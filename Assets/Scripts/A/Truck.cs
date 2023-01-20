using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public int maxBoxnum = 20;// MAX 박스 수
    public int currentBoxnum = 0;//치운 박스 수
    public GameObject[] bildingBox = new GameObject[20];//치운 박스가 쌓이는 위치

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
        }
        if (currentBoxnum == maxBoxnum)
        {
            GameManager.instance.amissionClear = true;
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
