using UnityEngine;
[CreateAssetMenu(fileName = "newProjectile", menuName = "ScriptableObject/Projectiles")]
public class ProjectileSO : ScriptableObject
{
    public float speed;
    public float damage;
    public float fireRate;
    public GameObject projectilePreFab;
}
