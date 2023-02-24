using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAction : MonoBehaviour
{
    public List<Animator> animators = new List<Animator>();

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {

    }

    void CharacterAni(bool b)
    {
        foreach (var item in animators)
        {

        }
    }
}
