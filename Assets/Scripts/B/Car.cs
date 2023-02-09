using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float carSpeed = 4.0f;
    Vector3 frontCar;
    Vector3 backCar;
    bool crashed = false;

    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            crashed = true;
            audioSource.Play();
        }

        if (other.gameObject.layer == 9)
        {
            crashed = true;
        }

        if (other.gameObject.tag == "Player")
        {
            crashed = true;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            crashed = false;
        }

        if (other.gameObject.layer == 9)
        {
            crashed = false;
        }

        if (other.gameObject.tag == "Player")
        {
            crashed = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        frontCar = new Vector3(0.0f, 0.0f, carSpeed);
        backCar = new Vector3(0.0f, 0.0f, -carSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!crashed)
        {
            if (transform.rotation.y == 0)
            {
                transform.position += frontCar * Time.deltaTime;
            }
            else
            {
                transform.position += backCar * Time.deltaTime;
            }
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
