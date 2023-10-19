using UnityEngine;

public class MetalChunk : MonoBehaviour
{
    public float hp;
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagUtils.TAG_PROJECTILE))
        {
            Projectile projectile = other.gameObject.GetComponent<Projectile>();
            hp -= projectile.projectileSO.damage;
            CheckHp(hp);
            Debug.Log(hp);
        }
    }

    void CheckHp(float hp)
    {
        if (hp <= 0)
        {
            DestroyMe();
        }
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
