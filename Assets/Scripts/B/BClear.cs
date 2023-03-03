using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BClear : MonoBehaviour
{
    public Transform player;
    public Transform spawnPoint;

    private bool isClearPos = false;

    public GameObject pressButton;

    struct ObjectSpawn
    {
        public ObjectSpawn(Vector3 pos, Quaternion rot)
        {
            objectPosition = pos;
            objectRotation = rot;
        }

        public Vector3 objectPosition;
        public Quaternion objectRotation;
    }

    static ObjectSpawn playerSpawn;

    private void Start()
    {
        playerSpawn = new ObjectSpawn(spawnPoint.position, spawnPoint.rotation);
    }

    private void Update()
    {
        if (isClearPos)
        {
            if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
            {
                StopCoroutine(GoRoom());
                //GameManager.instance.bmissionClear = false;
                isClearPos = false;
                LodingSceneManager.LoadScene("Room", "Non");
            }
            if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
            {
                StopCoroutine(GoRoom());
                //GameManager.instance.bmissionClear = false;
                isClearPos = false;
                LodingSceneManager.LoadScene("Room", "Non");
            }
        }
    }

    public void ClearSpawn()
    {
        player.position = playerSpawn.objectPosition;
        player.rotation = playerSpawn.objectRotation;

        isClearPos = true;

        StartCoroutine(GoRoom());
    }

    IEnumerator GoRoom()
    {
        /////
        yield return new WaitForSeconds(4.0f);
        pressButton.SetActive(true);

        yield return new WaitForSeconds(20.0f);

        //GameManager.instance.bmissionClear = false;
        isClearPos = false;
        LodingSceneManager.LoadScene("Room", "Non");
    }
}
