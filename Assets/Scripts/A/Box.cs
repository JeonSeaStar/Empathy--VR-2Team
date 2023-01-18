using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject abletoGrab;
    public TriggerShoot triggerShoot;
    BoxCollider bc;

    void Start()
    {
        triggerShoot = null;
        bc = gameObject.GetComponent<BoxCollider>();
    }

    void Update()
    {
        ShootBox();
    }


    void ShootBox()
    {
        if(triggerShoot.shoot)
        {
            abletoGrab.SetActive(false);
            transform.Translate(Vector3.forward * 50 * Time.deltaTime);
            bc.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            triggerShoot = col.gameObject.GetComponent<TriggerShoot>();
            if (triggerShoot != null)
            {
                bc.enabled = false;
            }
        }
        if(col.gameObject.CompareTag("Ground"))
        {
            abletoGrab.SetActive(true);
            bc.enabled = true;
        }
    }
}
