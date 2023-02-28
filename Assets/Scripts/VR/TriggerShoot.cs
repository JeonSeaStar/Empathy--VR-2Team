using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus;
using OculusSampleFramework;

public class TriggerShoot : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip ac;
    OVRHapticsClip oc;
    private void Start()
    {
        oc = new OVRHapticsClip(ac);
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            //OVRInput.SetControllerVibration(0.2f, 0.4f, OVRInput.Controller.RHand);
            audioSource.PlayOneShot(audioSource.clip);
            OVRHaptics.RightChannel.Preempt(oc);
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            //OVRInput.SetControllerVibration(0.2f, 0.4f, OVRInput.Controller.LHand);
            audioSource.PlayOneShot(audioSource.clip);
            OVRHaptics.LeftChannel.Preempt(oc);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Box"))
        //{
        //    og = other.gameObject.GetComponent<OVRGrabbable>();
        //    playSound = true;
        //    OVRInput.SetControllerVibration(0.2f, 0.1f);
        //    if(playSound)
        //    {
        //        audioSource.PlayOneShot(clips[1]);
        //        playSound = false;
        //    }
        //    //og = other.GetComponent<OVRGrabbable>();
        //}
        //if (og.isGrabbed)
        //{
        //    audioSource.PlayOneShot(clips[1]);
        //    OVRInput.SetControllerVibration(0.2f, 0.1f);
        //}
    }
}
