using UnityEngine;
public class MetalScrapManager : MonoBehaviour
{
    public static MetalScrapManager Instance { get; private set; }
    #region CONSTS
    public const float BASE_PRICE_FIREATE = 50;
    public const float BASE_PRICE_DAMAGE =  100f;
    public const float BASE_PRICE_SPEED =  100f;
    public const float BASE_PRICE_AMOUNT = 100f;
    public const float BASE_PRICE_CRITICAL_SHOT = 100f;
    public const float BASE_PRICE_ENERGY_SHIELD = 100f;
    public const float BASE_PRICE_ENERGY_SHIELD_REGEN = 100f;
    public const float BASE_PRICE_MOVESPEED = 100f;
    public const float BASE_PRICE_TURBO = 100f;
    // UPGRADE
    public const float UPGRADE_PRICE_FIREATE = 100f;
    public const float UPGRADE_PRICE_DAMAGE =  100f;
    public const float UPGRADE_PRICE_SPEED =  100f;
    public const float UPGRADE_PRICE_AMOUNT = 100f;
    public const float UPGRADE_PRICE_CRITICAL_SHOT = 100f;
    public const float UPGRADE_PRICE_ENERGY_SHIELD = 100f;
    public const float UPGRADE_PRICE_ENERGY_SHIELD_REGEN = 100f;
    public const float UPGRADE_PRICE_MOVESPEED = 100f;
    public const float UPGRADE_PRICE_TURBO = 100f;
    #endregion  

    private float current_price_firerate = BASE_PRICE_FIREATE;
    private float current_price_damage = BASE_PRICE_DAMAGE;
    private float current_price_speed = BASE_PRICE_SPEED;
    private float current_price_amount = BASE_PRICE_AMOUNT;
    private float current_price_critical_shot = BASE_PRICE_CRITICAL_SHOT;
    private float current_price_energy_shield = BASE_PRICE_ENERGY_SHIELD;
    private float current_price_energy_shield_regen = BASE_PRICE_ENERGY_SHIELD_REGEN;
    private float current_price_movespeed = BASE_PRICE_MOVESPEED;
    private float current_price_turbo = BASE_PRICE_TURBO;




    public CollectableSO collectableSO;
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(Instance);
        }else Destroy(Instance);
    }
    void Start()
    {
        UIUpgrade.Instance.OnUpgradeIncrease += BuyUpgrade;
    }

    private void BuyUpgrade(UpgradeEnum upgradeEnum){
        // Gastar meu Metal Scrap em troca do Upgrade Increase
        switch(upgradeEnum){
            case UpgradeEnum.FIRERATE:
            Debug.Log("BuyUpgrade FIRERATE CALLED");
            current_price_firerate = current_price_firerate + (current_price_firerate - 16f) * 1.5f; 
            collectableSO.metalScrap -= current_price_firerate;
            break;
            case UpgradeEnum.DAMAGE:
            break;
            case UpgradeEnum.SPEED:
            break;
            case UpgradeEnum.AMOUNT:
            break;
            case UpgradeEnum.CRITICAL_SHOT:
            break;
            case UpgradeEnum.ENERGY_SHIELD:
            break;
            case UpgradeEnum.ENERGY_SHIELD_REGEN:
            break;
            case UpgradeEnum.MOVESPEED:
            break;
            case UpgradeEnum.TURBO:
            break;
        }
    }
}
