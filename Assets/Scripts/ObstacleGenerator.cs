using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private GameObject[] objectsToSpawn;

    [SerializeField] private float spawnDelay = 2f;

    private Vector3 lastLineToSpawn;

    private bool isSpawningActive = false;

    private void Update()
    {
        if (GameController.isStarted && !isSpawningActive)
        {
            StartCoroutine(SpawnObstacle());
            isSpawningActive = true;
        }
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            var lineToSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

            while (lastLineToSpawn.x == lineToSpawn.x)
            {
                lineToSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

            }

            SpawnObstacle(lineToSpawn);

            lastLineToSpawn = lineToSpawn;
        }
    }

    private void SpawnObstacle(Vector3 position)
    {
        

        GameObject obj = objectPooler.GetPooledObject(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)]);

        obj.transform.position = position;

        obj.SetActive(true);
    }

    //private void Rotate()
    //{
    //    rb.AddTorque(new Vector3(Rand(), Rand(), Rand()) * 5);
    //}

    //private float Rand()
    //{
    //    return Random.Range(0f, 1f);
    //}

}
