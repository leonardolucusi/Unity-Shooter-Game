using System.Collections;
using UnityEngine;

public class GenericReSpawnTimer : MonoBehaviour
{
    public static GenericReSpawnTimer Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void CallChangeColorOnHitDuration(SpriteRenderer enemyRenderer, float duration)
    {
        StartCoroutine(ChangeColorOnHitDuration(enemyRenderer, duration));
    }

    IEnumerator ChangeColorOnHitDuration(SpriteRenderer enemyRenderer, float duration)
    {
        enemyRenderer.color = Color.red;
        yield return new WaitForSeconds(duration);
        if (enemyRenderer != null) enemyRenderer.color = Color.green;
    }

    public void RespawnEnemy(GameObject instance, float duration)
    {
        StartCoroutine(Timer(instance, duration));
    }

    public IEnumerator Timer(GameObject instance, float duration)
    {
        if (instance.CompareTag(TagUtils.TAG_ENEMY))
        {
            yield return new WaitForSeconds(duration);
            if (instance != null) instance.SetActive(true);
        }
        else if (instance.CompareTag(TagUtils.TAG_METALCHUNK))
        {
            yield return new WaitForSeconds(duration);
            instance.SetActive(true);
        }
    }
}
