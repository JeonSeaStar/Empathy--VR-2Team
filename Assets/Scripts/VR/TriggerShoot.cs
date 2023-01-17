using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus;
using OculusSampleFramework;

public class TriggerShoot : MonoBehaviour
{
    bool isGived = false;
    public bool shoot = false;
    //public GameObject box;

     void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && isGived == true || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) && isGived == true)
        {
            shoot = true;
        }
        else { shoot = false; }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Box"))
        {
           // box = other.gameObject;
            isGived = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
           // box = null;
            isGived = false;
        }
    }
}
