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
    public Transform playerStartPosition;
    public GameObject playerUI;
    public CharacterController playercc;
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
        player.transform.position = playerStartPosition.position;

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
            playercc.enabled = false;
            fade.SetActive(true);
            aClearUI.SetActive(true);
            fadeAni.SetTrigger("FadeOut");
            clearAni.enabled = true;
        }
        else
        {
            playercc.enabled = true;
            fade.SetActive(false);
            aClearUI.SetActive(false);
            fadeAni.SetTrigger("FadeIn");
            clearAni.enabled = false;
        }
    }
}
