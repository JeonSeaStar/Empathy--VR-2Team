using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public SocketChecker s;
    public Socket firstSocket;
    public Socket secondSocket;
    public Oculus.Interaction.Grabbable gb;
    public Cable js;
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

    public AudioClip ac;
    OVRHapticsClip oc;
    bool rClick;
    bool lClick;
    bool rightPlayH = false;
    bool leftPlayH = false;

    private void Start()
    {
        oc = new OVRHapticsClip(ac);
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            rClick = true;
        }
        if (gb.isGrabed && rClick && !rightPlayH)
        {
            OVRHaptics.RightChannel.Preempt(oc);
            rightPlayH = true;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            lClick = true;
        }
        if (gb.isGrabed && lClick && !leftPlayH)
        {
            OVRHaptics.LeftChannel.Preempt(oc);
            leftPlayH = true;
        }


        //if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger) && gb.isGrabed)
        //{
        //    OVRHaptics.RightChannel.Preempt(oc);
        //}

        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
        {
            rClick = false;
            rightPlayH = false;
            OVRHaptics.RightChannel.Clear();
            if (gb.isGrabed && !firstSocket.connect)
            {
                ads.PlayOneShot(audioClips[0]);
                firstSocket.connect = true;
                secondSocket = firstSocket;
                secondSocket.connect = true;
                connect = true;
            }
        }

        if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        {
            lClick = false;
            leftPlayH = false;
            OVRHaptics.LeftChannel.Clear();
            if (gb.isGrabed && !firstSocket.connect)
            {
                ads.PlayOneShot(audioClips[0]);
                firstSocket.connect = true;
                secondSocket = firstSocket;
                secondSocket.connect = true;
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
            firstSocket.connect = false;
            secondSocket.connect = false;
            secondSocket = null;

            if (connect)
            {
                connect = false;
                _rconnect = false;
                secondSocket.connect = false;
                secondSocket = null;
                firstSocket = null;
            }
        }

        if(secondSocket != null)
        {
            if (secondSocket.connect)
            {
                if (secondSocket.h == num)
                {
                    go.SetActive(false);
                    if (!_rconnect)
                        _rconnect = true;
                }
            }
        }

        if (firstSocket != null)
        {
            if(connect)
            {
                transform.position = firstSocket.t.position;
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
            firstSocket = other.GetComponent<Socket>();
            secondSocket = other.GetComponent<Socket>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            firstSocket.connect = false;
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
                return cc.citizenA;
            case 1:
                return cc.citizenB;
            case 2:
                return cc.citizenC;
            case 3:
                return cc.citizenD;
            case 4:
                return cc.citizenE;
            case 5:
                return cc.citizenF;
            case 6:
                return cc.citizenG;
            case 7:
                return cc.citizenH;
            default:
                return null;
        }
    }
}
