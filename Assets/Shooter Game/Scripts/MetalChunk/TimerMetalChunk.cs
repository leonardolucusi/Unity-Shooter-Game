using System.Collections;
using UnityEngine;

public class TimerMetalChunk : MonoBehaviour
{
    public static TimerMetalChunk Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void TriggerTimerToReSpawn(GameObject metalChunk)
    {
        StartCoroutine(Timer(metalChunk));
    }
    public IEnumerator Timer(GameObject metalChunk)
    {
        metalChunk.SetActive(false);
        yield return new WaitForSeconds(2);
        metalChunk.SetActive(true);
        metalChunk.GetComponent<MetalChunk>().hp = 10;


    }
}