using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    private const int maxCat = 11;
    public GameObject[] catPrefab = new GameObject[maxCat];
    private Queue<GameObject> catSpawnQueue = new Queue<GameObject>();

    [Header("Cat Spawn Parameter")]
    public float catSpawnInterval = 3.0f;
    public int catMaxSpawnCount = 5;

    struct SpawnRange
    {
        public SpawnRange(Vector3 start, Vector3 end)
        {
            startRange = start;
            endRange = end;
        }

        public Vector3 startRange;
        public Vector3 endRange;
    }

    private SpawnRange catSpawnRange;
    private Vector3 rotationOffset = Vector3.zero;

    private bool gameClear = false;

    private void Start()
    {
        catSpawnRange = new SpawnRange(new Vector3(97.5f, 24.32f, 370.0f), new Vector3(101.5f, 24.32f, 440.0f));
        rotationOffset = new Vector3(0.0f, -90.0f, 0.0f);

        StartCoroutine(SpawnCat());
    }

    IEnumerator SpawnCat()
    {
        while (!gameClear)
        {
            if (catSpawnQueue.Count <= catMaxSpawnCount - 1)
            {
                Vector3 catSpawnPos = new Vector3(Random.Range(catSpawnRange.startRange.x, catSpawnRange.endRange.x), Random.Range(catSpawnRange.startRange.y, catSpawnRange.endRange.y), Random.Range(catSpawnRange.startRange.z, catSpawnRange.endRange.z)); // Cat spawn position
                int catIndex = Random.Range(0, maxCat);

                Instantiate(catPrefab[catIndex], catSpawnPos, Quaternion.Euler(rotationOffset));

                catSpawnQueue.Enqueue(catPrefab[catIndex]);
            }

            yield return new WaitForSeconds(catSpawnInterval);
        }
    }

    private void OnApplicationQuit()
    {
        StopCoroutine(SpawnCat());
    }
}
