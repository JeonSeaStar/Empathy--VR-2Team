using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("플레이어")]
    public GameObject player;
    [Header("각 씬 접속 확인")]
    public bool mainScene = true;
    public bool aScene = false;
    public bool bScene = false;
    public bool cScene = false;
    [Header("시간관련")]
    public Time time;
    [Header("플레이어 스폰")]
    public Transform aSpawn;
    public Transform bSpawn;
    public Transform cSpawn;

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
        if (aScene && SceneManager.sceneCount == 1)
        {
            if (aSpawn == null)
            {
                aSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
                player.transform.position = aSpawn.position;

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
