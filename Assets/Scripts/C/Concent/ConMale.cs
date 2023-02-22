using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus;
using OculusSampleFramework;
using UnityEngine.XR;

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

            if(rconnect)
            {
                ads.PlayOneShot(audioClips[1]);
                cc.cheering_event(AnimatorList(numm));
            }
            else
                ads.PlayOneShot(audioClips[2]);
            js.check();
        }
    }
    public int num = -1;
    public scrip s;
    public scri ss;
    public scri sss;
    public Oculus.Interaction.Grabbable gb;
    public JeonSeon js;
    public AudioClip[] audioClips;
    public AudioSource ads;
    public float lerpSpeed;
    public float t;
    public float f;
    public float a;
    bool leftBool;
    public GameObject go;
    public Vector3 ro;

    public CClear cc;
    public int numm;

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
        {
            if (gb.isGrabed && !ss.connect)
            {
                ads.PlayOneShot(audioClips[0]);
                ss.connect = true;
                sss = ss;
                sss.connect = true;
                connect = true;
            }
        }

        if (connect && !rg.isKinematic) { rg.isKinematic = true; }
        if(!connect && rg.isKinematic)
        { rg.isKinematic = false; }

        if(gb.isGrabed)
        {
            rg.useGravity = false;
            //js.os.gravity = new Vector3(0, 0, 0);
            Haptic();
        }
        else
        {
            rg.useGravity = true;
            //js.os.gravity = new Vector3(0, -9.81f, 0);
            ss.connect = false;
            sss.connect = false;
            sss = null;

            if (connect)
            {
                connect = false;
                _rconnect = false;
                sss.connect = false;
                sss = null;
                ss = null;
            }
        }

        if(sss != null)
        {
            if (sss.connect)
            {
                if (sss.h == num)
                {
                    go.SetActive(false);
                    if (!_rconnect)
                        _rconnect = true;
                }
            }
        }

        if (ss != null)
        {
            if(connect)
            {
                transform.position = ss.t.position;
                transform.rotation = Quaternion.Euler(ro);
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
            sss = other.GetComponent<scri>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            ss.connect = false;
            female_con = null;
            grap = false;
        }
    }

    void Haptic()
    {
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
            OVRInput.SetControllerVibration(f, a, OVRInput.Controller.RHand);
        if (OVRInput.Get(OVRInput.RawButton.LHandTrigger))
            OVRInput.SetControllerVibration(f, a, OVRInput.Controller.LHand);
        Amplitude();
    }

    void Amplitude()
    {
        if(a >= 0.4f) { leftBool = false; }
        else if(a <= 0.1f) { leftBool = true; }

        if (leftBool)
        {
            t += Time.deltaTime * lerpSpeed;
        }
        else
        {
            t -= Time.deltaTime * lerpSpeed;
        }

        a = Mathf.Lerp(0.1f, 0.4f, t);
    }

    List<Animator> AnimatorList(int i)
    {
        switch(i)
        {
            case 0:
                return cc.a;
            case 1:
                return cc.b;
            case 2:
                return cc.c;
            case 3:
                return cc.d;
            case 4:
                return cc.e;
            case 5:
                return cc.f;
            case 6:
                return cc.g;
            case 7:
                return cc.h;
            default:
                return null;
        }
    }
}
