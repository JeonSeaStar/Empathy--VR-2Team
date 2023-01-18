using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public int maxBoxnum = 20;//치워야하는 박스 수
    public int currentBoxnum = -1;//치운 박스 수
    public GameObject[] bildingBox = new GameObject[20];//치운 박스가 쌓이는 위치

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
