using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Ω√¿€")]
    //public GameObject Title;
    public GameObject aSceneUI;
    [Header("AScene")]
    public int currentBoxNum;
    public Text boxNum;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        AScene();
    }

    void AScene()
    {
        //if(GameManager.instance.aScene == true)
        //{
            //aSceneUI.SetActive(true);
            currentBoxNum = GameManager.instance.currentBoxNum + 1;
            boxNum.text = (20 - currentBoxNum).ToString();
        //}
    }
}
