using UnityEngine;

public class MetalChunkManager : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < ObjectPool.SharedInstance.amountToPool; i++)
        {
            float randomX = Random.Range(-100f, 100f);
            float randomY = Random.Range(-100f, 100f);
            GameObject metalChunk = ObjectPool.SharedInstance.GetPooledObject();
            if (metalChunk != null)
            {
                metalChunk.transform.position = new Vector3(randomX, randomY, 0);
                metalChunk.transform.rotation = Quaternion.identity;
                metalChunk.SetActive(true);
            }
        }
    }
    void Update()
    {

    }
}
