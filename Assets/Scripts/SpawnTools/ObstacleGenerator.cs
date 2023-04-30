using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private GameObject[] objectsToSpawn;

    [SerializeField] private float spawnDelay = 2f;

    private List<IWeighted> weightedObj = new List<IWeighted>();

    private Vector3 lastLineToSpawn;

    private bool isSpawningActive = false;

    private void Awake()
    {

        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            weightedObj.Add(objectsToSpawn[i].GetComponent<IWeighted>());
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

    public IWeighted RandomIWeightedObject()
    {
        int totalWeight = 0;

        foreach (var prefab in weightedObj)
        {
            totalWeight += prefab.GetWeight();
        }

        int randomWeight = Random.Range(0, totalWeight);

        int currentWeight = 0;

        foreach (var prefab in weightedObj)
        {
            currentWeight += prefab.GetWeight();

            if (currentWeight > randomWeight)
            {
                return prefab;
            }

            currentWeight = 0;

        }
        return null;
    }

    private void SpawnObstacle(Vector3 position)
    {
        var randIWeighted = RandomIWeightedObject();
        if (randIWeighted != null)
        {
            GameObject obj = objectPooler.GetPooledObject(randIWeighted.GetGameObject());
            obj.transform.position = position;

            obj.SetActive(true);
        }
    }


}
