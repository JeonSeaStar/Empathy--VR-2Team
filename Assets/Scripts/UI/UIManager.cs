using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Ω√¿€")]
    public GameObject playerUI;
    public bool isUIOn = false;
    public bool isGameOff = false;
    [Header("AScene")]
    public GameObject a;
    public GameObject box;
    public Text boxNum;
    [Header("BScene")]
    public GameObject b;
    public GameObject cat;
    public Text catNum;
    [Header("CScene")]
    public GameObject c;
    public GameObject plug;
    public Text plugNum;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        playerUI.SetActive(false);
        a.SetActive(false);
        b.SetActive(false);
        c.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        AScene();
        if(GameManager.instance.startScene || GameManager.instance.roomScene)
        {
            isUIOn = true;
            playerUI.SetActive(false);
        }
        else
        {
            isUIOn = false;
            playerUI.SetActive(true);
        }
        if(GameManager.instance.aScene)
        {
            AScene();
        }
        else if(GameManager.instance.bScene)
        {
            BScene();
        }
        else if(GameManager.instance.cScene)
        {
            CScene();
        }
    }

    void AScene()
    {
        a.SetActive(true);
        b.SetActive(false);
        c.SetActive(false);
            boxNum.text = (20 - GameManager.instance.currentBoxNum).ToString();
        if (GameManager.instance.amissionClear)
        {

        }
    }
    void BScene()
    {
        a.SetActive(false);
        b.SetActive(true);
        c.SetActive(false);
        catNum.text = (20 - GameManager.instance.currentBoxNum).ToString();       
        if (GameManager.instance.bmissionClear)
        {

        }
    }
    void CScene()
    {
        a.SetActive(false);
        b.SetActive(false);
        c.SetActive(true);
        plugNum.text = (20 - GameManager.instance.currentBoxNum).ToString();
        if (GameManager.instance.cmissionClear)
        {

        }
    }
}
