using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnDelay = 2f;

    private Vector3 lastLineToSpawn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(SpawnObstacle());
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
        Instantiate(sphere, position, Quaternion.identity);
    }
}
