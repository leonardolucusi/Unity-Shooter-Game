using UnityEngine;
public class Projectile : MonoBehaviour
{
    private GameObject player;
    public Vector3 direction;
    public ProjectileSO projectileSO;
    void Awake(){
        // Criar um novo SO e personalizar seus dados
        // projectileSO = ScriptableObject.CreateInstance<ProjectileSO>();
        // projectileSO.fireRate = 2f;
        // projectileSO.speed = 10f;
        // projectileSO.damage = 1f;
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
        transform.position += direction.normalized * projectileSO.speed * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other){
        Destroy(gameObject);
    }
}