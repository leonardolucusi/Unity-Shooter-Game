using System;
using UnityEngine;
[CreateAssetMenu(fileName = "newProjectile", menuName = "ScriptableObject/Projectiles")]
public class ProjectileSO : ScriptableObject
{
    #region CONST_MAX_VALUES
    #endregion
    public float speed;
    public float damage;
    public float fireRate;
    public float amount;
    public float criticalShot;
    public GameObject projectilePreFab;
    public void IncreaseStatus<T>(UpgradeEnum upgrade, T value)
    {
        if (value is IConvertible)
        {
            switch (upgrade)
            {
                case UpgradeEnum.FIRERATE:
                    fireRate -= Convert.ToSingle(value);
                    // metalScrap decrease
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
    public void DecreaseStatus<T>(UpgradeEnum upgrade, T value)
    {
        if (value is IConvertible)
        {
            switch (upgrade)
            {
                case UpgradeEnum.FIRERATE:
                    fireRate += Convert.ToSingle(value);
                    // metalScrap increase
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
    public void InitalProjectileData()
    {
        speed = 10;
        damage = 1;
        fireRate = 1.1f;
        amount = 1;
        criticalShot = 1 / 100;
    }
}
