using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIO : MonoBehaviour
{
    public Animator anime;
    public CClear cc;
    [HideInInspector] public int hash = Animator.StringToHash("IO");
    [HideInInspector] public int hash2 = Animator.StringToHash("LS");

    //void Start()
    //{
    //    anime.SetTrigger(hash);
    //    StartCoroutine(SceneLoad());
    //}

    public void Clear_Event_Setting()
    {
        cc.clear_setting();
    }

    public void Clear()
    {
        cc.clear_ani();
    }

    public void LoadeaScene()
    {
        LodingSceneManager.LoadScene("Room");
    }

    public IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(20f);
        anime.SetTrigger(hash2);
    }
}
