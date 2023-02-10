using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using OVR;
using Oculus;
using OculusSampleFramework;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("각 씬 접속 확인")]
    public bool startScene = true;
    public bool roomScene = false;
    public bool aScene = false;
    public bool bScene = false;
    public bool cScene = false;
    [HideInInspector]
    public int currentBoxNum;
    [HideInInspector]
    public int currentCatNum;
    [HideInInspector]
    public int currentPlugNum;
    [Header("미션")]
    public bool amissionClear = false;
    public bool aMissionReset = false;
    public bool bmissionClear = false;
    public bool cmissionClear = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (instance == null)
            instance = this;
    }


    void Update()
    {
        GameSystem();
    }


    void GameSystem()
    {
        StartScene();
        RoomScene();
        ASceneSystem();
    }

    void StartScene()
    {
        if (SceneManager.sceneCount == 0)
        {
            startScene = true;
            aScene = false;
            bScene = false;
            cScene = false;
        }
    }
    void RoomScene()
    {
        if (SceneManager.sceneCount == 1)
        {
            startScene = false;
            roomScene = true;
            aScene = false;
            bScene = false;
            cScene = false;
        }
    }
    void ASceneSystem()
    {
        if (SceneManager.sceneCount == 2)
        {
            startScene = false;
            aScene = true;
            bScene = false;
            cScene = false;         
        }

    }

}
