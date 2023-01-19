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
    public GameObject box = null;

     void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && isGrabbed == true || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && isGrabbed == true)
        {
            shoot = true;
        }
        else { shoot = false; }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Box"))
        {
            isGrabbed = true;
            box = other.gameObject;
            if(shoot)
            {
                box.transform.Translate(Vector3.forward * 500 * Time.deltaTime);
            }
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
