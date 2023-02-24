using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAction : MonoBehaviour
{
    public List<Animator> animators = new List<Animator>();
    int actionHash = Animator.StringToHash("Action");

    public List<Animator> bubbleAni = new List<Animator>();
    int bubbleHash = Animator.StringToHash("Bubble");

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            CharacterAni(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            CharacterAni(false);
    }

    void CharacterAni(bool b)
    {
        foreach (var item in animators)
        {
            item.SetBool(actionHash, b);
        }
        foreach (var item in bubbleAni)
        {
            StartCoroutine(BubbleOn(item, b));
        }
    }

    IEnumerator BubbleOn(Animator ani, bool b)
    {
        if(b)
        {
            yield return new WaitForSeconds(ani.GetComponent<BubbleEvent>().delay);
            ani.SetBool(bubbleHash, b);
        }
        else
        {
            yield return new WaitForSeconds(0f);
            ani.SetBool(bubbleHash, b);
        }
    }
}
