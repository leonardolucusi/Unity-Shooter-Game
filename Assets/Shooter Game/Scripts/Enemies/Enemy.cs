using System;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public event Action<int> RewardPlayerOnEnemyInactive;
    public event Action<GameObject, float> RespawnEnemyOnEnemyInactive;
    public event Action<GameObject> SetEnemyPositionOnEnemyInactive;
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
    }

    void Start()
    {
        RewardPlayerOnEnemyInactive += collectableSO.IncreaseMetalScrap;
        SetEnemyPositionOnEnemyInactive += GameObjectsSpawnerPosition.Instance.EnemyReSpawnPosition;
        RespawnEnemyOnEnemyInactive += GenericReSpawnTimer.Instance.RespawnEnemy;

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
            GenericReSpawnTimer.Instance.CallChangeColorOnHitDuration(gameObject, enemySO.durationBetweenHitColorChange);
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
            RespawnEnemyOnEnemyInactive?.Invoke(gameObject, enemySO.respawnCooldown);
            RewardPlayerOnEnemyInactive?.Invoke(metalScrapDrop);
            SetEnemyPositionOnEnemyInactive?.Invoke(gameObject);
        }
    }
}