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

    private void Awake()
    {
        for (int i = 0; i < objectsToSpawn.Length; i++)
        {

        }
    }

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

    public GameObject RandomIWeightedObject()
    {
        int totalWeight = 0;

        foreach (var prefab in objectsToWeight)
        {
            totalWeight += prefab.GetWeight();
        }

        int randomWeight = Random.Range(0, totalWeight);

        int currentWeight = 0;

        foreach (var prefab in objectsToSpawn)
        {
            currentWeight += prefab.GetWeight();

            if (currentWeight > randomWeight)
            {
                return prefab.GetGameObject();
            }

            currentWeight = 0;

        }
        return null;
    }

    private void SpawnObstacle(Vector3 position)
    {


        GameObject obj = objectPooler.GetPooledObject(RandomIWeightedObject());

        obj.transform.position = position;

        obj.SetActive(true);
    }


}
