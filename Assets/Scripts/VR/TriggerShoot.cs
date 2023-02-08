using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus;
using OculusSampleFramework;

public class TriggerShoot : MonoBehaviour
{
    public bool isGrabbed = false;
    public bool shoot = false;
    public AudioSource audioSource;
    public AudioClip[] clips;//0번 펄스건//1번 박스 줍는 사운드

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RHand);
            audioSource.PlayOneShot(clips[0]);
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.LHand);
            audioSource.PlayOneShot(clips[0]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            isGrabbed = true;
            audioSource.PlayOneShot(clips[1]);
            OVRInput.SetControllerVibration(0.2f, 0.2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            isGrabbed = false;
        }
    }
}
