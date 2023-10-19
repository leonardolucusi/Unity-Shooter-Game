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



    private float current_stat_fireRate = BASE_STAT_FIRERATE_TICK;
    private float current_stat_damage = BASE_STAT_DAMAGE_TICK;
    private float current_stat_speed = BASE_STAT_SPEED_TICK;
    private float current_stat_amount = BASE_STAT_AMOUNT_TICK;
    private float current_stat_energy_shield = BASE_STAT_ENERGY_SHIELD_TICK;
    private float current_stat_energy_shield_regen = BASE_STAT_ENERGY_SHIELD_REGEN_TICK;
    private float current_stat_movespeed = BASE_STAT_MOVESPEED_TICK;
    private float current_stat_turbo = BASE_STAT_TURBO_TICK;
    private float current_stat_critical_shot = BASE_STAT_CRITICAL_SHOT_TICK;

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(Instance);
        }else Destroy(Instance);
    }
    void Start(){
        UIUpgrade.Instance.OnUpgradeIncrease += UpgradeIncrease;
        UIUpgrade.Instance.OnUpgradeDecrease += UpgradeDecrease;
    }

    private void UpgradeIncrease(UpgradeEnum upgrade)
    {
        float upgradeValue = 0;
        switch (upgrade)
        {
            case UpgradeEnum.FIRERATE:
                current_stat_fireRate = UPGRADE_STAT_FIRERATE_TICK - 0.9f;
                upgradeValue = current_stat_fireRate;
                break;
            case UpgradeEnum.DAMAGE:
                current_stat_damage *= UPGRADE_STAT_DAMAGE_TICK;
                upgradeValue = current_stat_damage;
                break;
            case UpgradeEnum.SPEED:
                current_stat_speed *= UPGRADE_STAT_SPEED_TICK;
                upgradeValue = current_stat_speed;
                break;
            case UpgradeEnum.AMOUNT:
                current_stat_amount *= UPGRADE_STAT_AMOUNT_TICK;
                upgradeValue = current_stat_amount;
                break;
            case UpgradeEnum.ENERGY_SHIELD:
                current_stat_energy_shield *= UPGRADE_STAT_ENERGY_SHIELD_TICK;
                upgradeValue = current_stat_energy_shield;
                break;
            case UpgradeEnum.ENERGY_SHIELD_REGEN:
                current_stat_energy_shield_regen *=  UPGRADE_STAT_ENERGY_SHIELD_REGEN_TICK;
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
            case UpgradeEnum.CRITICAL_SHOT:
                current_stat_critical_shot *= UPGRADE_STAT_CRITICAL_SHOT_TICK;
                upgradeValue = current_stat_critical_shot;
                break;
        }
        OnUpgradeUpdatePlayerProjectile(upgrade, upgradeValue);
    }

    private void UpgradeDecrease(UpgradeEnum upgrade)
    {
        float upgradeValue = 0;
        switch (upgrade)
        {
            case UpgradeEnum.FIRERATE:
                current_stat_fireRate = UPGRADE_STAT_FIRERATE_TICK - 0.9f ;
                upgradeValue = current_stat_fireRate;
                break;
            case UpgradeEnum.DAMAGE:
                current_stat_damage *= UPGRADE_STAT_DAMAGE_TICK;
                upgradeValue = current_stat_damage;
                break;
            case UpgradeEnum.SPEED:
                current_stat_speed *= UPGRADE_STAT_SPEED_TICK;
                upgradeValue = current_stat_speed;
                break;
            case UpgradeEnum.AMOUNT:
                current_stat_amount *= UPGRADE_STAT_AMOUNT_TICK;
                upgradeValue = current_stat_amount;
                break;
            case UpgradeEnum.ENERGY_SHIELD:
                current_stat_energy_shield *= UPGRADE_STAT_ENERGY_SHIELD_TICK;
                upgradeValue = current_stat_energy_shield;
                break;
            case UpgradeEnum.ENERGY_SHIELD_REGEN:
                current_stat_energy_shield_regen *=  UPGRADE_STAT_ENERGY_SHIELD_REGEN_TICK;
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
            case UpgradeEnum.CRITICAL_SHOT:
                current_stat_critical_shot *= UPGRADE_STAT_CRITICAL_SHOT_TICK;
                upgradeValue = current_stat_critical_shot;
                break;
        }
        OnUpgradeDowngradePlayerProjectile(upgrade, upgradeValue);
    }

    private void OnUpgradeUpdatePlayerProjectile<T>(UpgradeEnum upgrade, T value){
        PlayerManager.Instance.GetCurrentProjectile.projectileSO.IncreaseStatus(upgrade, value);
    }
    private void OnUpgradeDowngradePlayerProjectile<T>(UpgradeEnum upgrade, T value){
        PlayerManager.Instance.GetCurrentProjectile.projectileSO.DecreaseStatus(upgrade, value);
    }
}