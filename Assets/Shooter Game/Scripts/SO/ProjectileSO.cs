using System;
using UnityEngine;
[CreateAssetMenu(fileName = "newProjectile", menuName = "ScriptableObject/Projectiles")]
public class ProjectileSO : ScriptableObject
{
    
    public float speed;
    public float damage;
    public float fireRate;
    public float amount;
    public float criticalShot;
    public GameObject projectilePreFab;
    public void IncreaseStatus<T>(UpgradeEnum upgrade, T value){
        if(value is IConvertible){
            switch (upgrade)
            {
                case UpgradeEnum.FIRERATE: 
                    fireRate += Convert.ToSingle(value);
                    break;

                case UpgradeEnum.DAMAGE: 
                    damage += Convert.ToSingle(value);
                    break;

                case UpgradeEnum.SPEED: 
                    speed += Convert.ToSingle(value);
                    break;

                case UpgradeEnum.AMOUNT: 
                    amount += Convert.ToSingle(value);
                    break;

                case UpgradeEnum.CRITICAL_SHOT: 
                    criticalShot += Convert.ToSingle(value);
                    break;
                
            }
        }
    }
     public void DecreaseStatus<T>(T value, UpgradeEnum upgrade){
        if(value is IConvertible){
            switch (upgrade)
            {
                case UpgradeEnum.FIRERATE: 
                    fireRate -= Convert.ToSingle(value);
                    break;

                case UpgradeEnum.DAMAGE: 
                    damage -= Convert.ToSingle(value);
                    break;

                case UpgradeEnum.SPEED: 
                    speed -= Convert.ToSingle(value);
                    break;

                case UpgradeEnum.AMOUNT: 
                    amount -= Convert.ToSingle(value);
                    break;

                case UpgradeEnum.CRITICAL_SHOT: 
                    criticalShot -= Convert.ToSingle(value);
                    break;
            }
        }
    }
}
