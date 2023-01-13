using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus;
using OculusSampleFramework;

public class Movement : MonoBehaviour
{
    public Transform rot;
    float moveSpeed = 2f;

    void Start()
    {
        transform.rotation = rot.rotation;
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 mov = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        Vector3 movv = new Vector3(mov.x * Time.deltaTime * moveSpeed, 0, mov.y * Time.deltaTime * moveSpeed);

        transform.position += movv;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movv), Time.deltaTime);
    }
}
