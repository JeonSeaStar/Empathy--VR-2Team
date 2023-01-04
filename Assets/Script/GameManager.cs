using UnityEngine;

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
        if (aScene)
        {

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
