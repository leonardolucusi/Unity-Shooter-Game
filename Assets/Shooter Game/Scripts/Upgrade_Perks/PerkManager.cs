using System;
using UnityEngine;
public class PerkManager : MonoBehaviour
{
    public static PerkManager Instance { get; private set; }
    #region CONSTS
    public const float BASE_STAT_FIRERATE_TICK = 1.0f;
    public const float BASE_STAT_DAMAGE_TICK = 1.0f;
    public const float BASE_STAT_SPEED_TICK = 1.0f;
    public const float BASE_STAT_AMOUNT_TICK = 1.0f;
    public const float BASE_STAT_ENERGY_SHIELD_TICK = 1.0f;
    public const float BASE_STAT_ENERGY_SHIELD_REGEN_TICK = 1.0f;
    public const float BASE_STAT_MOVESPEED_TICK = 1.0f;
    public const float BASE_STAT_TURBO_TICK = 1.0f;
    public const float BASE_STAT_CRITICAL_SHOT_TICK = 1.0f;
    public const float UPGRADE_STAT_FIRERATE_TICK = 1.0f;
    public const float UPGRADE_STAT_DAMAGE_TICK = 1.0f;
    public const float UPGRADE_STAT_SPEED_TICK = 1.0f;
    public const float UPGRADE_STAT_AMOUNT_TICK = 1.0f;
    public const float UPGRADE_STAT_ENERGY_SHIELD_TICK = 1.0f;
    public const float UPGRADE_STAT_ENERGY_SHIELD_REGEN_TICK = 1.0f;
    public const float UPGRADE_STAT_MOVESPEED_TICK = 1.0f;
    public const float UPGRADE_STAT_TURBO_TICK = 1.0f;
    public const float UPGRADE_STAT_CRITICAL_SHOT_TICK = 1.0f;
    #endregion
    #region BASE_STATS
    private float current_stat_fireRate = BASE_STAT_FIRERATE_TICK;
    private float current_stat_damage = BASE_STAT_DAMAGE_TICK;
    private float current_stat_speed = BASE_STAT_SPEED_TICK;
    private float current_stat_amount = BASE_STAT_AMOUNT_TICK;
    private float current_stat_energy_shield = BASE_STAT_ENERGY_SHIELD_TICK;
    private float current_stat_energy_shield_regen = BASE_STAT_ENERGY_SHIELD_REGEN_TICK;
    private float current_stat_movespeed = BASE_STAT_MOVESPEED_TICK;
    private float current_stat_turbo = BASE_STAT_TURBO_TICK;
    private float current_stat_critical_shot = BASE_STAT_CRITICAL_SHOT_TICK;
    #endregion
    public int firerate_level = 0;
    public int damage_level = 0;
    public int speed_level = 0;
    public int amount_level = 0;
    public int criticalShot_level = 0;
    public event Action<UpgradeEnum, int> IncrementLevelText;
    public event Action<UpgradeEnum, int> DecrementLevelText;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else Destroy(Instance);
    }
    void Start()
    {
        UIUpgrade.Instance.OnUpgradeIncrease += UpgradePerk;
        UIUpgrade.Instance.OnUpgradeDecrease += DowngradePerk;
    }

    private void UpgradePerk(UpgradeEnum upgrade)
    {
        float upgradeValue = 0;
        switch (upgrade)
        {
            case UpgradeEnum.FIRERATE:
                if (firerate_level < TagUtils.MAX_FIREATE_LEVEL)
                {
                    firerate_level++;
                    current_stat_fireRate = UPGRADE_STAT_FIRERATE_TICK - 0.9f;
                    upgradeValue = current_stat_fireRate;
                    IncrementLevelText.Invoke(UpgradeEnum.FIRERATE, firerate_level);
                }
                break;
            case UpgradeEnum.DAMAGE:
                current_stat_damage *= UPGRADE_STAT_DAMAGE_TICK;
                upgradeValue = current_stat_damage;
                IncrementLevelText.Invoke(UpgradeEnum.DAMAGE, damage_level);
                break;
            case UpgradeEnum.SPEED:
                current_stat_speed *= UPGRADE_STAT_SPEED_TICK;
                upgradeValue = current_stat_speed;
                IncrementLevelText.Invoke(UpgradeEnum.SPEED, speed_level);
                break;
            case UpgradeEnum.AMOUNT:
                current_stat_amount *= UPGRADE_STAT_AMOUNT_TICK;
                upgradeValue = current_stat_amount;
                IncrementLevelText.Invoke(UpgradeEnum.AMOUNT, amount_level);
                break;
            case UpgradeEnum.CRITICAL_SHOT:
                current_stat_critical_shot *= UPGRADE_STAT_CRITICAL_SHOT_TICK;
                upgradeValue = current_stat_critical_shot;
                IncrementLevelText.Invoke(UpgradeEnum.CRITICAL_SHOT, criticalShot_level);
                break;
            case UpgradeEnum.ENERGY_SHIELD:
                current_stat_energy_shield *= UPGRADE_STAT_ENERGY_SHIELD_TICK;
                upgradeValue = current_stat_energy_shield;
                break;
            case UpgradeEnum.ENERGY_SHIELD_REGEN:
                current_stat_energy_shield_regen *= UPGRADE_STAT_ENERGY_SHIELD_REGEN_TICK;
                upgradeValue = current_stat_energy_shield_regen;
                break;
            case UpgradeEnum.MOVESPEED:
                current_stat_movespeed *= UPGRADE_STAT_MOVESPEED_TICK;
                upgradeValue = current_stat_movespeed;
                break;
            case UpgradeEnum.TURBO:
                current_stat_turbo *= UPGRADE_STAT_TURBO_TICK;
                upgradeValue = current_stat_turbo;
                break;
        }
        OnUpgradeUpdatePlayerProjectile(upgrade, upgradeValue);
    }
    private void DowngradePerk(UpgradeEnum upgrade)
    {
        float upgradeValue = 0;
        switch (upgrade)
        {
            case UpgradeEnum.FIRERATE:
                if (firerate_level > TagUtils.MIN_LEVEL && firerate_level <= TagUtils.MAX_FIREATE_LEVEL)
                {
                    current_stat_fireRate = UPGRADE_STAT_FIRERATE_TICK - 0.9f;
                    upgradeValue = current_stat_fireRate;
                    firerate_level--;
                    DecrementLevelText.Invoke(UpgradeEnum.FIRERATE, firerate_level);
                }
                break;
            case UpgradeEnum.DAMAGE:
                current_stat_damage *= UPGRADE_STAT_DAMAGE_TICK;
                upgradeValue = current_stat_damage;
                DecrementLevelText.Invoke(UpgradeEnum.DAMAGE, damage_level);
                break;
            case UpgradeEnum.SPEED:
                current_stat_speed *= UPGRADE_STAT_SPEED_TICK;
                upgradeValue = current_stat_speed;
                DecrementLevelText.Invoke(UpgradeEnum.SPEED, speed_level);
                break;
            case UpgradeEnum.AMOUNT:
                current_stat_amount *= UPGRADE_STAT_AMOUNT_TICK;
                upgradeValue = current_stat_amount;
                DecrementLevelText.Invoke(UpgradeEnum.AMOUNT, amount_level);
                break;
            case UpgradeEnum.CRITICAL_SHOT:
                current_stat_critical_shot *= UPGRADE_STAT_CRITICAL_SHOT_TICK;
                upgradeValue = current_stat_critical_shot;
                DecrementLevelText.Invoke(UpgradeEnum.CRITICAL_SHOT, criticalShot_level);
                break;
            case UpgradeEnum.ENERGY_SHIELD:
                current_stat_energy_shield *= UPGRADE_STAT_ENERGY_SHIELD_TICK;
                upgradeValue = current_stat_energy_shield;
                break;
            case UpgradeEnum.ENERGY_SHIELD_REGEN:
                current_stat_energy_shield_regen *= UPGRADE_STAT_ENERGY_SHIELD_REGEN_TICK;
                upgradeValue = current_stat_energy_shield_regen;
                break;
            case UpgradeEnum.MOVESPEED:
                current_stat_movespeed *= UPGRADE_STAT_MOVESPEED_TICK;
                upgradeValue = current_stat_movespeed;
                break;
            case UpgradeEnum.TURBO:
                current_stat_turbo *= UPGRADE_STAT_TURBO_TICK;
                upgradeValue = current_stat_turbo;
                break;
        }
        OnUpgradeDowngradePlayerProjectile(upgrade, upgradeValue);
    }

    private void OnUpgradeUpdatePlayerProjectile<T>(UpgradeEnum upgrade, T value)
    {
        PlayerManager.Instance.GetCurrentProjectile.projectileSO.IncreaseStatus(upgrade, value);
    }
    private void OnUpgradeDowngradePlayerProjectile<T>(UpgradeEnum upgrade, T value)
    {
        PlayerManager.Instance.GetCurrentProjectile.projectileSO.DecreaseStatus(upgrade, value);
    }
}