using UnityEngine;
[CreateAssetMenu(fileName = "newEnemy", menuName = "ScriptableObject/Enemy")]
public class EnemySO : ScriptableObject
{
    public float moveSpeed;
    public float hp;
    public float durationBetweenHitColorChange;
    public Sprite sprite;
    public float respawnCooldown;
}
