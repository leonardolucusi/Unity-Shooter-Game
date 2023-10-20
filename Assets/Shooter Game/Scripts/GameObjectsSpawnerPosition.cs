using UnityEngine;

public class GameObjectsSpawnerPosition : MonoBehaviour
{
    public static GameObjectsSpawnerPosition Instance { get; private set; }
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
        for (int i = 0; i < ObjectPool.Instance.amountToPool; i++)
        {
            float randomX = Random.Range(-100f, 100f);
            float randomY = Random.Range(-100f, 100f);
            GameObject obj = ObjectPool.Instance.GetPooledObject();
            if (obj != null)
            {
                obj.transform.position = new Vector3(randomX, randomY, 0);
                obj.transform.rotation = Quaternion.identity;
                obj.SetActive(true);
            }
        }
    }


    public void EnemyReSpawnPosition(GameObject enemy)
    {
        float randomX = Random.Range(-100f, 100f);
        float randomY = Random.Range(-100f, 100f);
        enemy.transform.position = new Vector3(randomX, randomY, 0);
    }
}
