using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BSceneUI : MonoBehaviour
{
    public int clearCatAmount = 5;
    public int savedCatAmount = 0;

    public Text leftCat;

    public GameObject fade;
    public Animator fadeAni;

    //private void Start()
    //{
    //    fade.SetActive(true);
    //    fadeAni = fade.GetComponent<Animator>();
    //    fadeAni.SetTrigger("FadeOut");
    //}

    // Update is called once per frame
    void Update()
    {
        if (clearCatAmount - savedCatAmount <= 0)
        {
            CatSpawner.gameClear = true;
            leftCat.text = "0";
        }
        else
        {
            leftCat.text = (clearCatAmount - savedCatAmount).ToString();
        }

        if(CatSpawner.gameClear)
        {
            fadeAni.SetTrigger("FadeOut");
        }
    }
}
