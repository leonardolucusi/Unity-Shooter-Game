using System.Collections;
using UnityEngine;
public class Projectile : MonoBehaviour
{
    public static Projectile Instace { get; private set; }
    private GameObject player;
    public Vector3 direction;
    public float speed = 10f;
    public float damage = 1f;
    public float fireRate = 0.5f;
    void Awake(){
        Destroy(gameObject, 5f);
    }
    void Start(){
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        player = PlayerManager.Instance.gameObject;
    }
    void Update()
    {
        direction.z = 0f;
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other){
        Destroy(gameObject);
    }
    public void DecreaseFireRate(float decreaseNumber){
        fireRate -= decreaseNumber;
    }
    public void IncreaseFireRate(float increaseNumber){
        fireRate += increaseNumber;
    }
    public void IncreaseSpeed(float increaseNumber){
        speed += increaseNumber;
    }
    public void IncreaseDamage(float increaseNumber){
        damage += increaseNumber;
    }

}