using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSound : MonoBehaviour
{
    public AudioSource clearSound;
    public AudioClip soundClip;

    public void PlayClearSound()
    {
        clearSound.PlayOneShot(soundClip);
    }
}
