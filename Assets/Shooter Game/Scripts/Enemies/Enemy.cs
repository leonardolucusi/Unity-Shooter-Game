using System;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public event Action<int> RewardPlayerOnEnemyInactive;
    public event Action<GameObject, float> RespawnEnemyOnEnemyInactive;
    [SerializeField] private float _hp;
    private GameObject player;
    public CollectableSO collectableSO;
    public EnemySO enemySO;
    [SerializeField] private SpriteRenderer myRenderer;
    public int metalScrapDrop;
    public float EnemyHp { get { return _hp; } set { _hp = value; } }
    void Awake()
    {
        if (enemySO == null)
        {
            enemySO = ScriptableObject.CreateInstance<EnemySO>();
            _hp = enemySO.hp;
        }
        else _hp = enemySO.hp;
    }

    void Start()
    {
        RewardPlayerOnEnemyInactive += collectableSO.IncreaseMetalScrap;
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
            GenericReSpawnTimer.Instance.CallChangeColorOnHitDuration(myRenderer, enemySO.durationBetweenHitColorChange);
            ReceiveDamage(other.GetComponent<Projectile>().projectileSO.damage);
        }
    }

    public void ReceiveDamage(float damage)
    {
        _hp -= damage;
        CheckIfCanBeKilled(_hp);
    }

    public void CheckIfCanBeKilled(float hp)
    {
        if (hp <= 0)
        {

            RespawnEnemyOnEnemyInactive?.Invoke(gameObject, enemySO.respawnCooldown);
            RewardPlayerOnEnemyInactive?.Invoke(metalScrapDrop);
            gameObject.transform.position = Utils.RandomPositionVector2();
            _hp = 10;
            gameObject.SetActive(false);

        }
    }
}