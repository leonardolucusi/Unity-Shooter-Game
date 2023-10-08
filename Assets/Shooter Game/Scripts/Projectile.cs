using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 shootDirection;
    public float speed = 10f;
    void Start(){

    }
    void Update()
    {
        // Normaliza a direção para manter uma velocidade constante
        Vector3 normalizedDirection = shootDirection.normalized;
        // Move o projetil na direção normalizada com a velocidade desejada
        transform.Translate(normalizedDirection * speed * Time.deltaTime);
    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }

}