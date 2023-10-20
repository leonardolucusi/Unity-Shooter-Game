using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public List<GameObject> pooledObjects;
    public GameObject metalChunk;
    public GameObject enemy;
    public int enemyAmount;
    public int metalChunkAmount;
    [HideInInspector] public int amountToPool;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    void OnEnable()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < metalChunkAmount; i++)
        {
            tmp = Instantiate(metalChunk);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
        for (int i = 0; i < enemyAmount; i++)
        {
            tmp = Instantiate(enemy);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
        amountToPool = enemyAmount + metalChunkAmount;
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
