using UnityEngine;

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
