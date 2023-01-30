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
    public bool rconnect;
    public bool _rconnect
    {
        get { return rconnect; }
        set
        {
            rconnect = value;
            js.check();
        }
    }
    public int num = -1;
    public scrip s;
    public scri ss;
    public Oculus.Interaction.Grabbable gb;
    public JeonSeon js;

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger) && grap)
        { 
            transform.position = female_con.position;
            transform.rotation = Quaternion.identity;
            connect = true;
            if (ss.h == num)
            {
                _rconnect = true;
            }
        }

        if(connect && !rg.isKinematic) { rg.isKinematic = true; }
        if(!connect && rg.isKinematic) { rg.isKinematic = false; }

        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            if(connect && gb.isGrabed)
            {
                connect = false;
            }
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
