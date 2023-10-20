using System.Collections;
using UnityEngine;

public class MetalChunkReSpawnTimer : MonoBehaviour
{
    public static MetalChunkReSpawnTimer Instance { get; private set; }
    public float reSpawnTimer;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void TriggerTimerToReSpawn(GameObject metalChunk)
    {
        StartCoroutine(Timer(metalChunk));
    }

    public IEnumerator Timer(GameObject metalChunk)
    {
        metalChunk.SetActive(false);
        yield return new WaitForSeconds(reSpawnTimer);
        metalChunk.SetActive(true);
        metalChunk.GetComponent<MetalChunk>().hp = 10;
    }
}
