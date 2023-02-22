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
    public Rigidbody rigid;
    public BoxCollider bc;

    private void Start()
    {
        gb = GetComponent<Grabbable>();
    }

    private void Update()
    {
        Height();
        if (gb.isGrabed )
        {
            bc.enabled = false;
            rigid.useGravity = false;
            gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        }

        if (!gb.isGrabed)
        {
            bc.enabled = true;
            rigid.useGravity = true;
            gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
    }

    void Height()
    {
        if (gameObject.transform.position.y <= -15)
        {
            gameObject.transform.position = new Vector3(2, -13, 16);
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

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
            transform.position = new Vector3(2, -13, -4.5f);
        }
    }
}
