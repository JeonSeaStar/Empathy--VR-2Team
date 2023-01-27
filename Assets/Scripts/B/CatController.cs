using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Animator anim;
    //private int runTrigger = Animator.StringToHash("run");

    private bool isArrived = false;
    private bool isMove = false;

    private Vector3 targetPos;
    private Vector3 targetOffset = new Vector3(-30.0f, 0.0f, 0.0f);
    private Vector3 prePosition;

    public float walkSpeed = 0.5f;
    private float catVelocity;

    private void Update()
    {
        catVelocity = Velocity(transform.position);
    }

    private void Start()
    {
        prePosition = transform.position;
        targetPos = transform.position + targetOffset;
        StartCoroutine(CatWalk());
        StartCoroutine(CatAnimation());

        anim.SetBool("isMove", !isMove); // start
        isMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collider"))
        {
            isArrived = true;
        }
    }

    IEnumerator CatWalk()
    {
        while (!isArrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, walkSpeed * Time.deltaTime);
            yield return null;
        }

        yield break;
    }

    IEnumerator CatAnimation()
    {
        while (!isArrived)
        {
            anim.SetFloat("speed", catVelocity * Time.deltaTime);
            Debug.Log(catVelocity + "  " + catVelocity * Time.deltaTime);
            yield return null;
        }

        anim.SetFloat("speed", catVelocity * Time.deltaTime);
        yield break;
    }

    private void OnApplicationQuit()
    {
        StopCoroutine(CatWalk());
        StopCoroutine(CatAnimation());
    }

    private float Velocity(Vector3 current)
    {
        float distance = (current - prePosition).magnitude;
        float velocity = distance / Time.deltaTime;

        prePosition = current;

        return velocity;
    }
}
