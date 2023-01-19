using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
   // public GameObject abletoGrab;
    public TriggerShoot triggerShoot;
    GameObject truck;
    BoxCollider bc;

    void Start()
    {
        triggerShoot = null;
        bc = gameObject.GetComponent<BoxCollider>();
        truck = GameObject.FindGameObjectWithTag("Truck");
    }

    void Update()
    {
        ShootBox();
        Height();
    }


    void ShootBox()
    {
        if(triggerShoot.shoot)
        {
            //abletoGrab.SetActive(false);
            transform.Translate(truck.transform.position * 10 * Time.deltaTime);
            triggerShoot.isGrabbed = false;
            triggerShoot.shoot = false;
            triggerShoot = null;
        }
    }

    void Height()
    {
        if(gameObject.transform.position.y <= 24)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 24.41166f, gameObject.transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            triggerShoot = col.gameObject.GetComponent<TriggerShoot>();
            if (triggerShoot != null)
            {
            }
        }
        if(col.gameObject.CompareTag("Ground"))
        {
            //abletoGrab.SetActive(true);
            //bc.enabled = true;
        }
    }
}
