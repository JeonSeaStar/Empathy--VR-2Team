using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public int maxBoxnum = 20;// MAX �ڽ� ��
    public int currentBoxnum = -1;//ġ�� �ڽ� ��
    public GameObject[] bildingBox = new GameObject[20];//ġ�� �ڽ��� ���̴� ��ġ

    void Update()
    {
        OnBox();
    }

    void OnBox()
    {
        bildingBox[currentBoxnum].SetActive(true);
        GameManager.instance.currentBoxNum = currentBoxnum;
        if (currentBoxnum == maxBoxnum)
        {
            GameManager.instance.missionClear = true;
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
