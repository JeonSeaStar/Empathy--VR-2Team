using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Animator anim;
    public Animation catAnim;
    public Animation clearAnim;
    private CatSpawner catSpawner;
    private BSceneUI bSceneUI;

    public Oculus.Interaction.Grabbable grabbableObject;
    public CapsuleCollider catCollider;

    public AudioSource audioSource;
    public AudioClip[] clips;

    private bool isArrived = false;
    private bool isExit = false;
    private bool isExit2 = false;
    private bool isDestroy = false;
    private bool isMove = false;
    private bool isGround = false;

    private bool emojiOn = false;

    public bool clearCat = false;

    private Vector3 targetPos;
    private Vector3 targetOffset = new Vector3(-30.0f, 0.0f, 0.0f);
    private Vector3 exitPos = new Vector3(77.5f, 24.32f, 351.3f);
    private Vector3 exit2Pos = new Vector3(67.8f, 24.32f, 351.3f);
    private Vector3 destroyPos = new Vector3(68.18f, 22.2f, 362.5f);
    private Vector3 catPush = new Vector3(0.0f, 0.0f, 0.01f);

    public float walkSpeed = 0.2f;
    public float runSpeed = 2.0f;

    private void Start()
    {
        catSpawner = FindObjectOfType<CatSpawner>();
        bSceneUI = FindObjectOfType<BSceneUI>();
        catCollider = GetComponent<CapsuleCollider>();

        targetPos = transform.position + targetOffset;
        StartCoroutine(CatWalk());
        StartCoroutine(CatAnimation());

        isMove = true;

        anim.SetBool("isMove", isMove);
    }

    private void Update()
    {
        if (GameManager.instance.bmissionClear && clearCat && !emojiOn)
        {
            emojiOn = true;
            StartCoroutine(CatEmoji());
        }

        if (grabbableObject.isGrabed && catCollider.enabled)
        {
            catCollider.enabled = false;
        }

        if (!grabbableObject.isGrabed && !catCollider.enabled)
        {
            catCollider.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(10))
        {
            isGround = true;

            if (!isArrived)
                transform.rotation = Quaternion.LookRotation(CatRotator(targetPos));
            else if (!isExit)
                transform.rotation = Quaternion.LookRotation(CatRotator(exitPos));
            else if (!isExit2)
                transform.rotation = Quaternion.LookRotation(CatRotator(exit2Pos));
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer.Equals(10))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer.Equals(10))
        {
            isGround = false;
        }

        if (collision.gameObject.layer.Equals(10) && !isExit)
        {
            audioSource.PlayOneShot(clips[0]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collider"))
        {
            if (!isArrived)
            {
                bSceneUI.savedCatAmount++;
                audioSource.PlayOneShot(clips[1]);
                StartCoroutine(CatEmoji());
            }
            isArrived = true;

            transform.rotation = Quaternion.LookRotation(CatRotator(exitPos));
            StartCoroutine(CatExit());
        }
        else if (other.gameObject.CompareTag("Exit"))
        {
            isExit = true;

            transform.rotation = Quaternion.LookRotation(CatRotator(exit2Pos));
        }
        else if (other.gameObject.CompareTag("Exit2"))
        {
            isExit2 = true;

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
            if (isGround) transform.position = Vector3.MoveTowards(transform.position, targetPos, walkSpeed * Time.deltaTime);
            yield return null;
        }

        yield break;
    }

    IEnumerator CatExit()
    {
        while (!isExit)
        {
            if (isGround) transform.position = Vector3.MoveTowards(transform.position, exitPos, runSpeed * Time.deltaTime);
            yield return null;
        }

        while (!isExit2)
        {
            transform.position = Vector3.MoveTowards(transform.position, exit2Pos, runSpeed * Time.deltaTime);
            yield return null;
        }

        while (!isDestroy)
        {
            transform.position = Vector3.MoveTowards(transform.position, destroyPos, runSpeed * Time.deltaTime);
            transform.position += catPush;
            yield return null;
        }

        yield break;
    }

    IEnumerator CatAnimation()
    {
        while (!isDestroy)
        {
            if (isGround)
            {
                if (!isArrived)
                {
                    anim.SetFloat("speed", walkSpeed);
                }
                else
                {
                    anim.SetFloat("speed", runSpeed);
                }
            }
            else
            {
                anim.SetFloat("speed", 0.0f);
            }

            yield return null;
        }

        yield break;
    }

    IEnumerator CatEmoji()
    {
        while (!isDestroy)
        {
            catAnim.Play();
            yield return new WaitForSeconds(4.0f);
        }
    }

    private void OnApplicationQuit()
    {
        StopAllCoroutines();
    }
}
