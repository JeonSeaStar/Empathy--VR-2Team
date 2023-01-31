using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    UIManager _instance;
    public static UIManager instance;

    [Header("±âº»")]
    public GameObject player;
    public GameObject playerUI;
    public GameObject fade;
    public Animator fadeAni;
    [Header("AScene")]
    public GameObject a;
    public GameObject box;
    public int totalBoxNumInt = 10;
    public Text totalBoxNum;
    public Text currentboxNum;
    public GameObject aClearUI;
    public Animator clearAni;
    public Transform aClearTransform;

    void Start()
    {
        if (_instance == null)
        {
            instance = this;
        }
        fade.SetActive(false);
        aClearUI.SetActive(false);
        clearAni.enabled = false;
        fadeAni = fade.GetComponent<Animator>();
    }

    void Update()
    {
        AScene();
    }

    void AScene()
    {
        a.SetActive(true);
        totalBoxNum.text = totalBoxNumInt.ToString();
        currentboxNum.text = GameManager.instance.currentBoxNum.ToString();
        if (GameManager.instance.amissionClear)
        {
            fade.SetActive(true);
            aClearUI.SetActive(true);
            //player.transform.position = aClearTransform.position;
            //player.transform.rotation = aClearTransform.rotation;
            fadeAni.SetTrigger("FadeOut");
            clearAni.enabled = true;
        }
    }
}
