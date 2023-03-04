using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCar : MonoBehaviour
{
    public Car c;

    private void Start()
    {
        c = transform.GetComponentInParent<Car>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            c.time = 0.0f;
        }
    }
}
