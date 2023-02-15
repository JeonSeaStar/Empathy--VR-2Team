using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus;
using Oculus.Interaction;
using OculusSampleFramework;

public class Box : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClip;
    bool isGrounded = true;
    public Grabbable gb;
    public BoxCollider bc;

    private void Start()
    {
        gb = GetComponent<Grabbable>();  
    }

    private void Update()
    {
        Height();
        if (gb.isGrabed && bc.enabled)
        {
            bc.enabled = false;
        }

        if (!gb.isGrabed && !bc.enabled)
        {
            bc.enabled = true;
        }
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
            OVRInput.SetControllerVibration(0.1f, 0.8f);
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
