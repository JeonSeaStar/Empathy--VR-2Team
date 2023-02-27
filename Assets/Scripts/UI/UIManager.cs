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
    public CharacterController playercc;
    public GameObject fade;
    public GameObject fadeFailed;
    public Animator fadeAni;
    public Animator fadeFailedAni;
    public Timer timer;
    [Header("AScene")]
    public GameObject a;
    public GameObject box;
    public int totalBoxNumInt = 10;
    public Text totalBoxNum;
    public Text currentboxNum;
    public GameObject timerUI;
    public GameObject aClearUI;
    public GameObject aFailedUI;
    public GameObject anyButtonPress;
    public Animator clearAni;
    public Transform aClearTransform;

    private bool isClearPos = false;

    void Start()
    {
        if (_instance == null)
        {
            instance = this;
        }
        fade.SetActive(false);
        timerUI.SetActive(true);
        box.SetActive(true);
        aClearUI.SetActive(false);
        clearAni.enabled = false;
        anyButtonPress.SetActive(false);
        fadeAni = fade.GetComponent<Animator>();
    }

    void Update()
    {
        AScene();

        if (isClearPos)
        {
            if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
            {
                isClearPos = false;
                LodingSceneManager.LoadScene("Room", "Non");
            }
            if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
            {
                isClearPos = false;
                LodingSceneManager.LoadScene("Room", "Non");
            }
        }
    }

    void AScene()
    {
        a.SetActive(true);
        totalBoxNum.text = totalBoxNumInt.ToString();
        currentboxNum.text = GameManager.instance.currentBoxNum.ToString();
        if (GameManager.instance.amissionClear)
        {
            playercc.enabled = false;
            timerUI.SetActive(false);
            timer.StopTimer();
            box.SetActive(false);
            fade.SetActive(true);
            anyButtonPress.SetActive(true);
            aClearUI.SetActive(true);
            fadeAni.SetTrigger("FadeOut");
            clearAni.enabled = true;
            isClearPos = true;
        }
        if(timer.Time <= 0)
        {
            playercc.enabled = false;
            timerUI.SetActive(false);
            box.SetActive(false);
            fadeFailed.SetActive(true);
            aFailedUI.SetActive(true);
            fadeFailedAni.SetTrigger("FadeOut");
        }
    }
}
