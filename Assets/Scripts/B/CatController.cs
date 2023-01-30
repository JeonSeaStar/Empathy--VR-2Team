using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Animator anim;
    private CatSpawner catSpawner;

    private bool isArrived = false;
    private bool isExit = false;
    private bool isDestroy = false;
    private bool isMove = false;

    private Vector3 targetPos;
    private Vector3 targetOffset = new Vector3(-30.0f, 0.0f, 0.0f);
    private Vector3 exitPos = new Vector3(77.5f, 24.32f, 351.3f);
    private Vector3 destroyPos = new Vector3(67.8f, 24.32f, 351.3f);

    public float walkSpeed = 0.25f;
    public float runSpeed = 3.0f;

    private void Start()
    {
        catSpawner = FindObjectOfType<CatSpawner>();

        targetPos = transform.position + targetOffset;
        StartCoroutine(CatWalk());
        StartCoroutine(CatAnimation());

        isMove = true;

        anim.SetBool("isMove", isMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collider"))
        {
            isArrived = true;

            transform.rotation = Quaternion.LookRotation(CatRotator(exitPos));
            StartCoroutine(CatExit());
        }
        else if (other.gameObject.CompareTag("Exit"))
        {
            isExit = true;

            transform.rotation = Quaternion.LookRotation(CatRotator(destroyPos));
        }
        else if (other.gameObject.CompareTag("Destroy"))
        {
            isDestroy = true;

            catSpawner.catSpawnQueue.Dequeue();
            Destroy(gameObject);
        }
    }

    Vector3 CatRotator(Vector3 destination)
    {
        return destination - transform.position;
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

    IEnumerator CatExit()
    {
        while (!isExit)
        {
            transform.position = Vector3.MoveTowards(transform.position, exitPos, runSpeed * Time.deltaTime);
            yield return null;
        }

        while (!isDestroy)
        {
            transform.position = Vector3.MoveTowards(transform.position, destroyPos, runSpeed * Time.deltaTime);
            yield return null;
        }

        yield break;
    }

    IEnumerator CatAnimation()
    {
        while (!isDestroy)
        {
            if (!isArrived)
            {
                anim.SetFloat("speed", walkSpeed);
            }
            else
            {
                anim.SetFloat("speed", runSpeed);
            }

            yield return null;
        }

        yield break;
    }

    private void OnApplicationQuit()
    {
        StopAllCoroutines();
    }
}
