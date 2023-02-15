using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float rotate = 36;

    private void Update()
    {
        transform.Rotate(0, 0, rotate * Time.deltaTime);
    }
}
