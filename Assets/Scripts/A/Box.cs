using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject abletoGrab;
    public TriggerShoot triggerShoot;

    void Start()
    {
        triggerShoot = null;
    }

    void Update()
    {
        ShootBox();
        Attached();
    }


    void ShootBox()
    {
        if(triggerShoot.shoot)
        {
            Debug.Log("던져던져던져");
            abletoGrab.SetActive(false);
            transform.Translate(Vector3.forward * 100 * Time.deltaTime);
        }
    }

    void Attached()
    {
        if(triggerShoot.isGrabbed)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            triggerShoot = col.gameObject.GetComponent<TriggerShoot>();
        }
        if(col.gameObject.CompareTag("Ground"))
        {
            abletoGrab.SetActive(true);
        }
    }
}
