using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public struct ObjectPool
    {
        public GameObject objectToPool;
        public int poolSize;
    }

    [SerializeField] private List<ObjectPool> objectPools;

    private Dictionary<GameObject, List<GameObject>> pooledObjects = new Dictionary<GameObject, List<GameObject>>();

    private int newInstanceCount = 0;

    private void Start()
    {
        foreach (ObjectPool objectPool in objectPools)
        {
            List<GameObject> pool = new List<GameObject>();

            for (int i = 0; i < objectPool.poolSize; i++)
            {
                GameObject obj = Instantiate(objectPool.objectToPool);
                obj.SetActive(false);
                pool.Add(obj);
            }

            pooledObjects.Add(objectPool.objectToPool, pool);
        }
    }

    public GameObject GetPooledObject(GameObject objectToPool)
    {
        List<GameObject> pool;

        if (pooledObjects.TryGetValue(objectToPool, out pool))
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    return pool[i];
                }
            }

            GameObject obj = Instantiate(objectToPool);
            newInstanceCount++;
            Debug.Log("New instance count: " + newInstanceCount);
            obj.SetActive(false);
            pool.Add(obj);
            return obj;
        }
        else
        {
            Debug.LogError("Object pool not found.");
            return null;
        }
    }
}
