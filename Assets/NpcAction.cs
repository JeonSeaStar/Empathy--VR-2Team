using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAction : MonoBehaviour
{
    public List<Animator> animators = new List<Animator>();
    int actionHash = Animator.StringToHash("Action");

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
    }
}
