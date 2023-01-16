using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus;
using OculusSampleFramework;

public class Gun : MonoBehaviour
{
    public GameObject originPosition;
    public GameObject position;
    public float speed;
    public bool isGet = false;
    RaycastHit hit;
    [SerializeField]
    LayerMask lm;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShootGun();
        DrowBox();
    }

    void ShootGun()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && isGet == false)
        {
            Debug.DrawRay(transform.position, Vector3.forward * 99999, Color.cyan);
            if (Physics.Raycast(transform.position, transform.forward, out hit, lm))
            {
                position = hit.collider.gameObject;
            }
        }
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) && isGet == false)
        {
            Vector3.Lerp(position.transform.position, originPosition.transform.position, speed);
            isGet = true;
        }
    }

    void DrowBox()
    {
        if(OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && isGet == true)
        {
            position.transform.Translate(Vector3.forward * 10);
            isGet = false;
        }
    }
}
