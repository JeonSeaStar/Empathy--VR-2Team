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
    public AudioClip[] audioClips;
    public AudioSource ads;

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
        {
            if (gb.isGrabed && !ss.connect)
            {
                transform.position = female_con.position;
                transform.rotation = Quaternion.identity;
                ads.PlayOneShot(audioClips[0]);
                ss.connect = true;
                connect = true;
                if (ss.h == num)
                {
                    _rconnect = true;
                    ads.PlayOneShot(audioClips[1]);
                }
                else
                {
                    ads.PlayOneShot(audioClips[2]);
                }
            }
        }

        if (connect && !rg.isKinematic) { rg.isKinematic = true; }
        if(!connect && rg.isKinematic)
        { rg.isKinematic = false; }

        if(gb.isGrabed)
        {
            rg.useGravity = false;
            js.os.gravity = new Vector3(0, 0, 0);
        }
        else
        {
            rg.useGravity = true;
            js.os.gravity = new Vector3(0, -9.81f, 0);
        }

        if(!grap)
        {
            if (connect)
            {
                connect = false;
                _rconnect = false;
                ss = null;
                ads.PlayOneShot(audioClips[0]);
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
            ss.connect = false;
            female_con = null;
            grap = false;
            //ss = null;
        }
    }
}
