using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private GameObject[] objectsToSpawn;

    [SerializeField] private float spawnDelay = 2f;

    private Vector3 lastLineToSpawn;

    private bool isSpawningActive = false;

    //public GameObject ObjectWeight(GameObject[] objects)
    //{

    //    int totalWeight = 0;

    //    foreach (var obj in objects)
    //    {
    //        totalWeight += obj.Weight;
    //    }

    //    int randomWeight = Random.Range(0, totalWeight);

    //    foreach (var obj in objects)
    //    {
    //        if (randomWeight < obj.Weight)
    //        {
    //            return obj;
    //        }
    //        randomWeight -= obj.Weight;
    //    }

    //    return null;


    //}
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


}
