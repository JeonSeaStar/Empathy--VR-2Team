using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadChaser : MonoBehaviour
{
    public bool look;
    //{
    //    get { return look; }
    //    set
    //    {
    //        look = value;
    //        if (!look)
    //            ResetRotation();
    //        else
    //            StartCoroutine(LookMe());
    //    }
    //}

    Vector3 targetPosition;
    public Transform playerTransform;
    public Vector3 roatation;
    Quaternion q;
    public Vector3 playerPosition;

    Vector3 CatRotator(Vector3 destination)
    {
        return destination - transform.position;
    }

    public float a = 0;
    public Quaternion originQ;

    void Awake() => originQ = transform.rotation;

    public IEnumerator LookMe()
    {
        //q = Quaternion.LookRotation(CatRotator(playerTransform.position));
        //transform.rotation = q;
        //yield return new WaitForSeconds(0.1f);
        //StartCoroutine(LookMe());
        
        q = Quaternion.LookRotation(CatRotator(playerTransform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, q, a);

        if (playerPosition != playerTransform.position)
        {
            playerPosition = playerTransform.position;
            a = 0;
        }

        yield return new WaitForSeconds(0.05f);

        if (a < 1)
        {
            a += 0.05f;
        }
        else if (a > 1)
        {
            a = 1;
        }

        StartCoroutine(LookMe());
    }

    public void LookAtMe()
    {
        StopCoroutines();
        a = 0;
        playerPosition = playerTransform.position;
        StartCoroutine(LookMe());
    }

    public IEnumerator ResetRotation()
    {
        //transform.localRotation = Quaternion.Euler(roatation);
        if (a < 1)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(roatation), a);
            a += 0.05f;
        }
        else if (a > 1)
        {
            a = 1;
        }

        yield return new WaitForSeconds(0.05f);

        StartCoroutine(ResetRotation());
    }

    public void StartResetRotation()
    {
        StartCoroutine(ResetRotation());
    }

    public void StopCoroutines()
    {
        StopAllCoroutines();
    }
}
