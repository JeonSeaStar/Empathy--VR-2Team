using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Oculus.Interaction.Throw;

namespace Oculus.Interaction
{
    public class MoveObject : MonoBehaviour
    {
        public Oculus.Interaction.Grabbable gb;
        public GameObject p;
        public float speed = 1;
        public Pose currentpose;
        Transform a;

        void Update()
        {
            if (gb.isGrabed)
            {
                //currentpose = transform.GetPose();
                if (OVRInput.Get(OVRInput.RawButton.A)) 
                {
                    currentpose.position.z += transform.position.z;
                    transform.position = Vector3.MoveTowards(transform.position, p.transform.position, speed * Time.deltaTime);
                    transform.SetPose(currentpose);

                }
                if (OVRInput.Get(OVRInput.RawButton.B)) { transform.position = Vector3.MoveTowards(transform.position, p.transform.position, -speed * Time.deltaTime); }
            }
        }
    }
}
