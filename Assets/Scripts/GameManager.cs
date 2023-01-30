using UnityEngine;
using UnityEngine.SceneManagement;
using OVR;
using Oculus;
using OculusSampleFramework;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("�÷��̾�")]
    public GameObject player;
    public GameObject uiHelper;
    [Header("�� �� ���� Ȯ��")]
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
    [Header("�ð�����")]
    public Time time;
    [Header("�÷��̾� ����")]
    public Transform aSpawn;
    public Transform bSpawn;
    public Transform cSpawn;
    [Header("�̼�")]
    public bool amissionClear = false;
    public bool bmissionClear = false;
    public bool cmissionClear = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //DontDestroyOnLoad(player);
    }

    void Start()
    {
        if(instance == null)
            instance = this;
    }


    void Update()
    {
        GameSystem();
    }


    void GameSystem()
    {
        if(UIManager.instance.isUIOn == true){uiHelper.SetActive(true);}
        else { uiHelper.SetActive(false); }
        StartScene();
        RoomScene();
        ASceneSystem();
        BSceneSystem();
        CSceneSystem();
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
            if (aSpawn == null)
            {
                aSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
                player.transform.position = aSpawn.position;
            }
            if (amissionClear == true)
            {

            }
            bSpawn = null;
            cSpawn = null;
        }

    }

    void BSceneSystem()
    {
        if (SceneManager.sceneCount == 3)
        {
            startScene = false;
            aScene = false;
            bScene = true;
            cScene = false;
            if (bSpawn == null)
            {
                bSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
                player.transform.position = bSpawn.position;
            }
            if (bmissionClear == true)
            {

            }
            aSpawn = null;
            cSpawn = null;

        }
    }

    void CSceneSystem()
    {
        if (SceneManager.sceneCount == 4)
        {
            startScene = false;
            aScene = false;
            bScene = false;
            cScene = true;
            if (cSpawn == null)
            {
                cSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
                player.transform.position = cSpawn.position;
            }
            if (cmissionClear == true)
            {

            }
            bSpawn = null;
            cSpawn = null;

        }
    }
}
