using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public GameObject box;//트럭에 쌓아줄 박스 프리팹
    public int maxBoxnum = 20;//치워야하는 박스 수
    public int currentBoxnum = 0;//치운 박스 수
    public Transform[] bildingBox = new Transform[20];//치운 박스가 쌓이는 위치
    bool isbildingbox = false;//박스를 쌓는 중인지

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
