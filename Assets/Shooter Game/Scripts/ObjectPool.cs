using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public List<GameObject> pooledObjects;
    public GameObject metalChunk;
    public GameObject enemy;
    public GameObject enemy2;
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

    void Start()
    {
        pooledObjects = new List<GameObject>(enemyAmount + metalChunkAmount);
        GameObject tmp;
        // for (ushort i = 0; i < metalChunkAmount; i++)
        // {
        //     tmp = Instantiate(metalChunk);
        //     tmp.SetActive(false);
        //     pooledObjects.Add(tmp);
        // }
        for (ushort i = 0; i < enemyAmount; i++)
        {
            tmp = Instantiate(enemy);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
        amountToPool = enemyAmount + metalChunkAmount;

        for (ushort i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                if (pooledObjects[i] != null)
                {
                    pooledObjects[i].transform.SetPositionAndRotation(Utils.RandomPositionVector2(), Quaternion.identity);
                    pooledObjects[i].SetActive(true);
                }
            }
        }
    }

    public void OnZoneChanged()
    {
        float rng = Random.Range(0.0f, 100.0f);
        if (rng < ZoneManager.ZONE2_THRESHOLD) return;

        for (ushort i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                Destroy(pooledObjects[i]);
                pooledObjects[i] = Instantiate(enemy2);
                Debug.Log("Enemy changed");
            }
        }
    }
}
