using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus;
using OculusSampleFramework;

public class TriggerShoot : MonoBehaviour
{
    public bool shoot = false;
    public OVRGrabbable og;
    public bool playSound = false;
    public AudioSource audioSource;
    public AudioClip[] clips;//0번 펄스건//1번 박스 줍는 사운드

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            OVRInput.SetControllerVibration(0.2f, 0.1f, OVRInput.Controller.RHand);
            audioSource.PlayOneShot(clips[0]);
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            OVRInput.SetControllerVibration(0.2f, 0.1f, OVRInput.Controller.LHand);
            audioSource.PlayOneShot(clips[0]);
        }
        if (og.isGrabbed)
        {
            audioSource.PlayOneShot(clips[1]);
            OVRInput.SetControllerVibration(0.2f, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            og = other.gameObject.GetComponent<OVRGrabbable>();
            playSound = true;
            OVRInput.SetControllerVibration(0.2f, 0.1f);
            if(playSound)
            {
                audioSource.PlayOneShot(clips[1]);
                playSound = false;
            }
            //og = other.GetComponent<OVRGrabbable>();
        }
        if (og.isGrabbed)
        {
            audioSource.PlayOneShot(clips[1]);
            OVRInput.SetControllerVibration(0.2f, 0.1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {

        }
    }
}
