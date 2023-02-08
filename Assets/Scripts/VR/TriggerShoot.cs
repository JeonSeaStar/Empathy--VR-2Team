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

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Box"))
        {
            isGrabbed = true;
            box = other.gameObject;
            box.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            isGrabbed = false;
            box.GetComponent<BoxCollider>().enabled = true;
            box = null;
        }
    }
}
