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
    [Header("�� �� ���� Ȯ��")]
    public bool mainScene = true;
    public bool aScene = false;
    public bool bScene = false;
    public bool cScene = false;
    [Header("AScene")]
    public int currentBoxNum = -1;
    [Header("�ð�����")]
    public Time time;
    [Header("�÷��̾� ����")]
    public Transform aSpawn;
    public Transform bSpawn;
    public Transform cSpawn;
    [Header("�̼�")]
    public bool missionClear = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player);
    }

    void Start()
    {

    }


    void Update()
    {
        GameSystem();
    }


    void GameSystem()
    {
        ASceneSystem();
        BSceneSystem();
        CSceneSystem();
    }

    void ASceneSystem()
    {
        if (SceneManager.sceneCount == 1)
        {
            aScene = true;
            bScene = false;
            cScene = false;
            if (aSpawn == null)
            {
                aSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
                player.transform.position = aSpawn.position;
                if(missionClear == true)
                {

                }
            }
            bSpawn = null;
            cSpawn = null;

        }
    }

    void BSceneSystem()
    {
        if (bScene)
        {

        }
    }

    void CSceneSystem()
    {
        if (cScene)
        {

        }
    }
}
