using System.Collections;
using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    public float moveSpeed = 10f;
    private GameObject player;
    public float hp = 2f;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = PlayerManager.Instance.player;
    }
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        // transform.Translate(direction * moveSpeed * Time.deltaTime);           
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag(TagUtils.TAG_PROJECTILE)){
            StartCoroutine(ChangeColorOnHitDuration(0.5f));
            ReceiveDamage(1f);
        }
    }
    public void ReceiveDamage(float damage){        
        hp -= damage;
        print(hp);
        CheckIfCanBeKilled(hp);
    }
    public void CheckIfCanBeKilled(float hp){
        if(hp <= 0 ){
            Destroy(gameObject);
        }
    }
    IEnumerator ChangeColorOnHitDuration(float duration){
        sr.color = Color.red;
        yield return new WaitForSeconds(duration);
        sr.color = Color.green;
    }
    IEnumerator DelayBetweenHit(){
        yield return null;
    }
}