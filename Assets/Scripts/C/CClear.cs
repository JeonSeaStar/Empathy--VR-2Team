using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CClear : MonoBehaviour
{
    public Animation ani;
    public List<Animator> ill;
    public List<Animation> ill_emoji;
    public List<Animator> yi;
    public List<Animation> yi_emoji;
    int walk_hash = Animator.StringToHash("Walking");
    int cheer_hash = Animator.StringToHash("Cheering");
    public Transform player;
    public Transform player_setting;
    public GameObject clear_npc;
    public float delay;
    public Text text;
    [TextArea] public string talk;
    int t = 0;
    public Animator clear_npc_ani;
    int ot = Animator.StringToHash("ot");
    public CharacterController playerController;
    public List<Animator> a;
    public List<Animator> b;
    public List<Animator> c;
    public List<Animator> d;
    public List<Animator> e;
    public List<Animator> f;
    public List<Animator> g;
    public List<Animator> h;
    public GameObject z;

    public void clear_ani()
    {
        playerController.enabled = false;
        ani.Play();
        clear_npc_ani.SetTrigger(ot);
        StartCoroutine(output_text());
        GameManager.instance.cmissionClear = true;
        playerController.enabled = false;
    }

    public void clear_setting()
    {
        player.position = player_setting.position;
        player.rotation = player_setting.rotation;
        clear_npc.SetActive(true);
    }

    void ill_walk_event()
    {
        for(int i = 0; i < ill.Count; i++)
        {
            ill[i].SetTrigger(walk_hash);
            ill_emoji[i].Play();
        }
    }

    void yi_walk_event()
    {
        for (int i = 0; i < yi.Count; i++)
        {
            yi[i].SetTrigger(walk_hash);
            yi_emoji[i].Play();
        }
    }

    public void cheering_event(List<Animator> animators)
    {
        for (int i = 0; i < animators.Count; i++)
        {
            animators[i].SetTrigger(cheer_hash);
        }
    }

    IEnumerator output_text()
    {
        text.text += talk[t]; 
        yield return new WaitForSeconds(delay);
        if (t < talk.Length - 1)
        {
            t++;
            StartCoroutine(output_text());
        }
    }
}
