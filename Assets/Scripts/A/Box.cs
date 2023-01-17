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
    }


    void ShootBox()
    {
        if(triggerShoot.shoot == true)
        {
            Debug.Log("������������");
            abletoGrab.SetActive(false);
            transform.Translate(Vector3.forward * 100 * Time.deltaTime);
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
