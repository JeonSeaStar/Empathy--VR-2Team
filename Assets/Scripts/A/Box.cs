using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClip;
    bool isGrounded = true;
    private void Update()
    {
        Height();
    }

    void Height()
    {
        if (gameObject.transform.localPosition.y <= -16)
        {
            gameObject.transform.localPosition = new Vector3(2, -13, -4.5f);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && isGrounded)
        {
            audioSource.PlayOneShot(audioClip[0]);
            isGrounded = false;
        }
        if (col.CompareTag("Ground") && !isGrounded)
        {
            audioSource.PlayOneShot(audioClip[1]);
            isGrounded = true;
        }
        if (col.CompareTag("DeadZone"))
        {
            transform.localPosition = new Vector3(2, -13.7f, -4.5f);
        }
    }
}
