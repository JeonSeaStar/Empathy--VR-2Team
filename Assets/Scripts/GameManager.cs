using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using OVR;
using Oculus;
using OculusSampleFramework;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public int currentBoxNum;
    [HideInInspector]
    public int currentCatNum;
    [HideInInspector]
    public int currentPlugNum;
    [Header("¹Ì¼Ç")]
    public bool amissionClear = false;
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
             
    }

}
