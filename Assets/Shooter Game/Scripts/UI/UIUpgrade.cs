using System;
using UnityEngine;
using UnityEngine.UIElements;
public class UIUpgrade : MonoBehaviour
{
    public static UIUpgrade Instance { get; private set; }
    public event Action<UpgradeEnum> OnUpgradeIncrease;
    public event Action<UpgradeEnum> OnUpgradeDecrease;
    private VisualElement root;
    private bool isPaused = false;
    VisualElement upgradeTab;
    Button moreFireRateButton;
    Button lessFireRateButton;
    Button moreDamageButton;
    Button lessDamageButton;
    Button moreSpeedButton;
    Button lessSpeedButton;
    Button moreAmountButton;
    Button lessAmountButton;
    Button moreCriticalShotButton;
    Button lessCriticalShotButton;
    void Awake(){
        if(Instance == null){
            Instance = this;
        }else Destroy(Instance);
    }
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        
        upgradeTab = root.Q<VisualElement>("upgradeTab");
        upgradeTab.visible = true;
        
        moreFireRateButton = root.Q<Button>("moreFireRateButton");
        lessFireRateButton = root.Q<Button>("lessFireRateButton");
        moreFireRateButton.clicked += () => IncreaseUpgrade(UpgradeEnum.FIRERATE);
        lessFireRateButton.clicked += () => DecreaseUpgrade(UpgradeEnum.FIRERATE);

        moreDamageButton = root.Q<Button>("moreDamageButton");
        lessDamageButton = root.Q<Button>("lessDamageButton");
        moreDamageButton.clicked += () => IncreaseUpgrade(UpgradeEnum.DAMAGE);
        lessDamageButton.clicked += () => DecreaseUpgrade(UpgradeEnum.DAMAGE);

        moreSpeedButton = root.Q<Button>("moreSpeedButton");
        lessSpeedButton = root.Q<Button>("lessSpeedButton");
        moreSpeedButton.clicked += () => IncreaseUpgrade(UpgradeEnum.SPEED);
        lessSpeedButton.clicked += () => DecreaseUpgrade(UpgradeEnum.SPEED);

        moreAmountButton = root.Q<Button>("moreAmountButton");
        lessAmountButton = root.Q<Button>("lessAmountButton");
        moreAmountButton.clicked += () => IncreaseUpgrade(UpgradeEnum.AMOUNT);
        lessAmountButton.clicked += () => DecreaseUpgrade(UpgradeEnum.AMOUNT);

        moreCriticalShotButton = root.Q<Button>("moreCriticalShotButton");
        lessCriticalShotButton = root.Q<Button>("lessCriticalShotButton");
        moreCriticalShotButton.clicked += () => IncreaseUpgrade(UpgradeEnum.CRITICAL_SHOT);
        lessCriticalShotButton.clicked += () => DecreaseUpgrade(UpgradeEnum.CRITICAL_SHOT);
    }
    void Update(){
        // Pausa o jogo, pausa incompleta
        if (Input.GetKeyDown(KeyCode.P)){
            if (isPaused)
            {
                Time.timeScale = 1f;
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }
    private void IncreaseUpgrade(UpgradeEnum upgrade){
        OnUpgradeIncrease?.Invoke(upgrade);
    }
    private void DecreaseUpgrade(UpgradeEnum downgrade){
        OnUpgradeDecrease?.Invoke(downgrade);
    }    
}
