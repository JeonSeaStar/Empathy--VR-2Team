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
    public int num = -1;
    public scrip s;
    public scri ss;

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger) && grap)
        { 
            transform.position = female_con.position;
            transform.rotation = Quaternion.identity;
            connect = true;
            s.haha(this, ss.h);
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
            ss = other.GetComponent<scri>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            female_con = null;
            grap = false;
            ss = null;
        }
    }
}
