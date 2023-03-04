using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float carSpeed = 4.0f;
    Vector3 frontCar;
    Vector3 backCar;
    public bool crashed = false;
    public float time = 0.0f;

    bool isCar = false;

    public AudioSource audioSource;

    Animation anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11 && !crashed)
        {
            crashed = true;
            audioSource.Play();
        }

        if (other.gameObject.layer == 9 && !crashed)
        {
            isCar = true;
            crashed = true;
            time = 0.0f;
        }

        if (other.gameObject.tag == "Player" && !crashed)
        {
            crashed = true;
            audioSource.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            time = 0.0f;
        }

        //if (other.gameObject.layer == 9)
        //{
        //    crashed = true;
        //}

        if (other.gameObject.tag == "Player")
        {
            time = 0.0f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();

        frontCar = new Vector3(0.0f, 0.0f, carSpeed);
        backCar = new Vector3(0.0f, 0.0f, -carSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 5.0f)
        {
            time = 0.0f;
            crashed = false;
        }

        if (!crashed)
        {
            if (!anim.isPlaying) anim.Play();

            if (transform.rotation.y == 0)
            {
                transform.position += frontCar * Time.deltaTime;
            }
            else
            {
                transform.position += backCar * Time.deltaTime;
            }
        }
        else
        {
            if (anim.isPlaying) anim.Stop();
        }

        if (transform.position.z >= 500)
        {
            transform.position += new Vector3(0.0f, 0.0f, -500.0f);
        }
        if (transform.position.z <= 100)
        {
            transform.position += new Vector3(0.0f, 0.0f, +500.0f);
        }
    }
}
