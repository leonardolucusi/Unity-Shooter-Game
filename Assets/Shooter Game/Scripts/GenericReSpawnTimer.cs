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

    public void CallChangeColorOnHitDuration(GameObject enemy, float duration)
    {
        StartCoroutine(ChangeColorOnHitDuration(enemy, duration));
    }
    IEnumerator ChangeColorOnHitDuration(GameObject enemy, float duration)
    {
        enemy.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(duration);
        enemy.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void RespawnEnemy(GameObject obj, float duration)
    {
        StartCoroutine(EnemyTimer(obj, duration));
    }

    public IEnumerator EnemyTimer(GameObject obj, float duration)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(duration);
        obj.SetActive(true);
        obj.GetComponent<Enemy>().hp = 10;
    }
}
