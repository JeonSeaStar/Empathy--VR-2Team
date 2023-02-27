using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIO : MonoBehaviour
{
    public Animator anime;
    public CClear cc;
    public scrip ss;
    [HideInInspector] public int hash = Animator.StringToHash("IO");
    [HideInInspector] public int hash2 = Animator.StringToHash("LS");
    public GameObject failedNPC;
    public Transform t;
    public Transform p;
    public CharacterController playerController;
    public GameObject timer;
    public GameObject z;
    public GameObject x;
    public Timer scTimer;
    public GameObject goal;

    void Update()
    {
        if(ss.clear)
        {
            if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
            {
                z.SetActive(false);
                x.SetActive(false);
                anime.SetTrigger(hash2);
                GameManager.instance.cmissionClear = true;
            }
            if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
            {
                z.SetActive(false);
                x.SetActive(false);
                anime.SetTrigger(hash2);
                GameManager.instance.cmissionClear = true;
            }
        }
    }

    public void Clear_Event_Setting()
    {
        scTimer.StopTimer();
        timer.SetActive(false);
        goal.SetActive(false);
        cc.clear_setting();
        cc.playerController.enabled = false;
    }

    public void Clear()
    {
        z.SetActive(true);
        cc.clear_ani();
    }

    public void LoadeaScene()
    {
        LodingSceneManager.LoadScene("Room","Non");
    }

    public IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(20f);
        anime.SetTrigger(hash2);
    }

    public void FailedEvent()
    {
        p.position = t.position;
        p.rotation = t.rotation;
        failedNPC.SetActive(true);
        playerController.enabled = false;

        Invoke("ls", 15.0f);
    }

    void ls()
    {
        anime.SetTrigger(hash2);
    }
}
