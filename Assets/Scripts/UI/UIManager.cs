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
    public bool isUIOn = false;
    public bool isGameOff = false;
    [Header("AScene")]
    public Text leftOfBox;
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
        MainScene();
    }

    void MainScene()
    {
        if (GameManager.instance.startScene)
        {
            isUIOn = true;
        }
    }
    void AScene()
    {
        //if(GameManager.instance.aScene == true)
        //{
            //aSceneUI.SetActive(true);
            boxNum.text = (20 - GameManager.instance.currentBoxNum).ToString();
        //}

        if(GameManager.instance.amissionClear)
        {
            boxNum.enabled = false;
            leftOfBox.text = "Clear";
        }
    }
}
