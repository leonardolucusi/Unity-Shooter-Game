using System;
using System.Collections;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public event Action<int> OnEnemyDeath;
    public float hp;
    private GameObject player;
    public CollectableSO collectableSO;
    public EnemySO enemySO;
    [SerializeField] private SpriteRenderer myRenderer;
    public int metalScrapDrop = 1;
    void Awake()
    {
        if (enemySO == null)
        {
            enemySO = ScriptableObject.CreateInstance<EnemySO>();
            hp = enemySO.hp;
        }

        // OnEnemyDeath += ScoreManager.Instance.IncreaseScoreOnEnemyKill; 
        OnEnemyDeath += collectableSO.IncreaseMetalScrap;

    }
    void Start()
    {
        myRenderer = gameObject.AddComponent<SpriteRenderer>();
        myRenderer.sprite = enemySO.sprite;
        myRenderer.color = Color.green;
        player = PlayerManager.Instance.gameObject;
    }
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySO.moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagUtils.TAG_PROJECTILE))
        {
            StartCoroutine(ChangeColorOnHitDuration(enemySO.durationBetweenHitColorChange));
            ReceiveDamage(other.GetComponent<Projectile>().projectileSO.damage);
        }
    }
    public void ReceiveDamage(float damage)
    {
        hp -= damage;
        CheckIfCanBeKilled(hp);
    }
    public void CheckIfCanBeKilled(float hp)
    {
        if (hp <= 0)
        {
            OnEnemyDeath?.Invoke(metalScrapDrop);
            Destroy(gameObject);
        }
    }
    IEnumerator ChangeColorOnHitDuration(float duration)
    {
        myRenderer.color = Color.red;
        yield return new WaitForSeconds(duration);
        myRenderer.color = Color.green;
    }
    private void OnDestroy()
    {
        OnEnemyDeath -= collectableSO.IncreaseMetalScrap;
    }
}
