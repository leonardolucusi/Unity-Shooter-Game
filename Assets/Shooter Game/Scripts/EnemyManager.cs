using System;
using System.Collections;
using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    // public event Action<Vector2> OnEnemyDeath2;
    public event Action OnEnemyDeath;
    public float moveSpeed = 10f;
    private GameObject player;
    public float hp = 3f;
    SpriteRenderer sr;
    public float durationBetweenHitColorChange = 0.1f;
    void Awake(){
        // OnEnemyDeath2 += PlayerManager.Instance.FireProjectile;
        OnEnemyDeath += ScoreManager.Instance.IncreaseScoreOnEnemyKill;   
        OnEnemyDeath += ScoreManager.Instance.MyMethod;   
    }
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
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag(TagUtils.TAG_PROJECTILE)){
            StartCoroutine(ChangeColorOnHitDuration(durationBetweenHitColorChange));
            ReceiveDamage(other.GetComponent<Projectile>().damage);
        }
    }
    public void ReceiveDamage(float damage){
        hp -= damage;
        CheckIfCanBeKilled(hp);
    }
    public void CheckIfCanBeKilled(float hp){
        if(hp <= 0 ){
            OnEnemyDeath?.Invoke(); // Invoke() - Invoca o método ou construtor atual.
            Destroy(gameObject);
        }
    }
    IEnumerator ChangeColorOnHitDuration(float duration){
        sr.color = Color.red;
        yield return new WaitForSeconds(duration);
        sr.color = Color.green;
    }
    private void OnDestroy(){
        OnEnemyDeath -= ScoreManager.Instance.IncreaseScoreOnEnemyKill;
    }
}
