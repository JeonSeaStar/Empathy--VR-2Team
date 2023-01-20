using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    private void Update()
    {
        Height();
    }

    void Height()
    {
        if(gameObject.transform.localPosition.y <= -16)
        {
            gameObject.transform.localPosition = new Vector3(2, -13, -4.5f);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        
        if(col.CompareTag("DeadZone"))
        {
            transform.localPosition = new Vector3(2, -13.7f, -4.5f);
        }
    }
}
