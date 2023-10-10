using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float moveSpeed = 10f;
    private GameObject player;
    void Start()
    {
        player = PlayerManager.Instance.player;    
    }
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * moveSpeed * Time.deltaTime);           
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Projectile")){
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
