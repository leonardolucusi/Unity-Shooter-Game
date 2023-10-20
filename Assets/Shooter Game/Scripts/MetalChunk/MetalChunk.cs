using System;
using UnityEngine;
public class MetalChunk : MonoBehaviour
{
    public event Action<int> OnMetalChunkInactive;
    public CollectableSO collectableSO;
    public float hp;
    public int metalScrapDrop = 10;
    void Start()
    {
        OnMetalChunkInactive += collectableSO.IncreaseMetalScrap;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagUtils.TAG_PROJECTILE))
        {
            Projectile projectile = other.gameObject.GetComponent<Projectile>();
            hp -= projectile.projectileSO.damage;
            CheckHp(hp);
        }
    }
    void CheckHp(float hp)
    {
        if (hp <= 0)
        {
            OnMetalChunkInactive?.Invoke(metalScrapDrop);
            MetalChunkReSpawnTimer.Instance.TriggerTimerToReSpawn(gameObject);
        }
    }
}
