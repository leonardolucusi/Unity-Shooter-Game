using System;
using UnityEngine;
public class MetalChunk : MonoBehaviour
{
    public event Action<int> RewardPlayerOnMetalChunkInactive;
    public event Action<GameObject, float> RespawnMetalChunkOnMetalChunkInactive;
    public CollectableSO collectableSO;
    [SerializeField] private float _hp;
    public int metalScrapDrop = 10;
    public float duration;
    void Start()
    {
        RewardPlayerOnMetalChunkInactive += collectableSO.IncreaseMetalScrap;
        RespawnMetalChunkOnMetalChunkInactive += GenericReSpawnTimer.Instance.RespawnEnemy;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagUtils.TAG_PROJECTILE))
        {
            _hp -= PlayerManager.Instance.GetCurrentProjectile.projectileSO.damage;
            CheckHp(_hp);
        }
    }
    void CheckHp(float hp)
    {
        if (hp <= 0)
        {

            RewardPlayerOnMetalChunkInactive?.Invoke(metalScrapDrop);
            RespawnMetalChunkOnMetalChunkInactive?.Invoke(gameObject, duration);
            gameObject.transform.position = Utils.RandomPositionVector2();

            _hp = 10;
            gameObject.SetActive(false);
        }
    }
}
