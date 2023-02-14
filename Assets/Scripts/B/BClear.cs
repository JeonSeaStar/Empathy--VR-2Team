using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BClear : MonoBehaviour
{
    public Transform player;
    public Transform spawnPoint;

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

    public void ClearSpawn()
    {
        player.position = playerSpawn.objectPosition;
        player.rotation = playerSpawn.objectRotation;

        StartCoroutine(GoRoom());
    }

    IEnumerator GoRoom()
    {
        yield return new WaitForSeconds(10.0f);

        GameManager.instance.bmissionClear = false;
        LodingSceneManager.LoadScene("Room", "Non");
    }
}
