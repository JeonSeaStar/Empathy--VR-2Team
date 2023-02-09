using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public int maxBoxnum = 10;// MAX �ڽ� ��
    public int currentBoxnum = 0;//ġ�� �ڽ� ��
    public GameObject[] bildingBox = new GameObject[10];//ġ�� �ڽ��� ���̴� ��ġ
    public AudioSource audioSource;

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
            for(int i =0; i<10;i++)
            {
                if(bildingBox[i].activeSelf != true)
                {
                    bildingBox[i].SetActive(true);
                }
            }
        }
        if(GameManager.instance.aMissionReset)
        {
            currentBoxnum = 0;
            for (int i = 0; i < 10; i++)
            {             
                    bildingBox[i].SetActive(false);
            }
            GameManager.instance.aMissionReset = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box") && currentBoxnum < 11)
        {
            currentBoxnum += 1;
            audioSource.PlayOneShot(audioSource.clip);
            Destroy(other.gameObject);
        }
    }
}
