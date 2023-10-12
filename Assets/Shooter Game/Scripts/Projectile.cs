using UnityEngine;
public class Projectile : MonoBehaviour
{
    void Awake(){
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D other){ 
        Destroy(gameObject);
    }
}