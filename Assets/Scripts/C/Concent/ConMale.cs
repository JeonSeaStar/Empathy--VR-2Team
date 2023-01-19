using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus;
using OculusSampleFramework;

public class ConMale : MonoBehaviour
{
    public bool grap = false;
    public Transform female_con;
    public Rigidbody rg;
    public bool connect;

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger) && grap)
        { 
            transform.position = female_con.position;
            transform.rotation = Quaternion.identity;
            connect = true;
            //rg.isKinematic = true;
        }

        if(connect && !rg.isKinematic) { rg.isKinematic = true; }
        if(!connect && rg.isKinematic) { rg.isKinematic = false; }

        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) && connect)
        {
            connect = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            female_con = other.transform;
            grap = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            female_con = null;
            grap = false;
        }
    }
}
