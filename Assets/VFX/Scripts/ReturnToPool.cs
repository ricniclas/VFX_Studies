using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Exception;
public class ReturnToPool : MonoBehaviour
{
    public Queue<GameObject> pool;
    public int poolSize;
    public GameObject explosionPrefab;

    public void Start()
    {
        populatePool();
    }

    public void populatePool()
    {
        pool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(explosionPrefab,gameObject.transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject getPolledObject()
    {
        GameObject objectToSpawn = pool.Dequeue();
        objectToSpawn.SetActive(false);
        pool.Enqueue(objectToSpawn);
        return objectToSpawn;
    }
    
}
