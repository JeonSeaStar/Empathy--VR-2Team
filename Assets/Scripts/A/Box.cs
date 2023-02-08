using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public AudioSource audioSource;
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
        if(col.CompareTag("Ground"))
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
        if(col.CompareTag("DeadZone"))
        {
            transform.localPosition = new Vector3(2, -13.7f, -4.5f);
        }
    }
}
