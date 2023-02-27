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

    Vector3 CatRotator(Vector3 destination)
    {
        return destination - transform.position;
    }

    IEnumerator LookMe()
    {
        q = Quaternion.LookRotation(CatRotator(playerTransform.position));
        transform.rotation = q;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(LookMe());
    }

    public void LookAtMe()
    {
        StartCoroutine(LookMe());
    }

    public void ResetRotation()
    {
        StopAllCoroutines();
        transform.localRotation = Quaternion.Euler(roatation);
    }
}
