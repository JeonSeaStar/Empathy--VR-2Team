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
    Vector3 playerPosition;

    Vector3 CatRotator(Vector3 destination)
    {
        return destination - transform.position;
    }

    public float a = 0;

    IEnumerator LookMe()
    {
        //q = Quaternion.LookRotation(CatRotator(playerTransform.position));
        //transform.rotation = q;
        //yield return new WaitForSeconds(0.1f);
        //StartCoroutine(LookMe());
        
        q = Quaternion.LookRotation(CatRotator(playerTransform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, q, a);
        a += 0.1f;

        if (playerTransform.position != playerTransform.position)
        {
            playerTransform.position = playerTransform.position;
            a = 0;
        }

        yield return new WaitForSeconds(0.5f);

        if(a <= 1)
        {
            StartCoroutine(LookMe());
        }
        else
        {
            a = 1;
            transform.rotation = Quaternion.Lerp(transform.rotation, q, a);
        }
    }

    public void LookAtMe()
    {
        playerTransform.position = playerTransform.position;
        StartCoroutine(LookMe());
    }

    public IEnumerator ResetRotation()
    {
        StopAllCoroutines();
        //transform.localRotation = Quaternion.Euler(roatation);
        transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(roatation), a);
        a -= 0.1f;

        yield return new WaitForSeconds(0.2f);

        if (a >= 0)
        {
            StartCoroutine(ResetRotation());
        }
        else
        {
            a = 0;
            transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(roatation), a);
        }
    }
}
