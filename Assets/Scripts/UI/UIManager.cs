using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Ω√¿€")]
    public GameObject Title;
    public GameObject aSceneUI;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        AScene();
    }

    void AScene()
    {
        if(GameManager.instance.aScene == true)
        {
            aSceneUI.SetActive(true);
        }
    }
}
