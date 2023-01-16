using UnityEngine;
using UnityEngine.SceneManagement;

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
    [Header("�ð�����")]
    public Time time;
    [Header("�÷��̾� ����")]
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
