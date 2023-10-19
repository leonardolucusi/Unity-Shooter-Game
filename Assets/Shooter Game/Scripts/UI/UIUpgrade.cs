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
    Label fireRateTextLVL;
    Button moreFireRateButton;
    Button lessFireRateButton;
    Label damageLVL;
    Button moreDamageButton;
    Button lessDamageButton;
    Label speedLVL;
    Button moreSpeedButton;
    Button lessSpeedButton;
    Label amountLVL;
    Button moreAmountButton;
    Button lessAmountButton;
    Label criticalShotLVL;
    Button moreCriticalShotButton;
    Button lessCriticalShotButton;
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
        PerkManager.Instance.IncrementLevelText += UpTextLVL;
        PerkManager.Instance.DecrementLevelText += DownTextLVL;

        root = GetComponent<UIDocument>().rootVisualElement;

        upgradeTab = root.Q<VisualElement>("upgradeTab");
        upgradeTab.visible = true;
        fireRateTextLVL = root.Q<Label>("fireRateLvl");
        moreFireRateButton = root.Q<Button>("moreFireRateButton");
        lessFireRateButton = root.Q<Button>("lessFireRateButton");
        moreFireRateButton.clicked += () => IncreaseUpgrade(UpgradeEnum.FIRERATE);
        lessFireRateButton.clicked += () => DecreaseUpgrade(UpgradeEnum.FIRERATE);

        damageLVL = root.Q<Label>("damageLvl");
        moreDamageButton = root.Q<Button>("moreDamageButton");
        lessDamageButton = root.Q<Button>("lessDamageButton");
        moreDamageButton.clicked += () => IncreaseUpgrade(UpgradeEnum.DAMAGE);
        lessDamageButton.clicked += () => DecreaseUpgrade(UpgradeEnum.DAMAGE);

        speedLVL = root.Q<Label>("speedLvl");
        moreSpeedButton = root.Q<Button>("moreSpeedButton");
        lessSpeedButton = root.Q<Button>("lessSpeedButton");
        moreSpeedButton.clicked += () => IncreaseUpgrade(UpgradeEnum.SPEED);
        lessSpeedButton.clicked += () => DecreaseUpgrade(UpgradeEnum.SPEED);

        amountLVL = root.Q<Label>("amountLvl");
        moreAmountButton = root.Q<Button>("moreAmountButton");
        lessAmountButton = root.Q<Button>("lessAmountButton");
        moreAmountButton.clicked += () => IncreaseUpgrade(UpgradeEnum.AMOUNT);
        lessAmountButton.clicked += () => DecreaseUpgrade(UpgradeEnum.AMOUNT);

        criticalShotLVL = root.Q<Label>("criticalShotLvl");
        moreCriticalShotButton = root.Q<Button>("moreCriticalShotButton");
        lessCriticalShotButton = root.Q<Button>("lessCriticalShotButton");
        moreCriticalShotButton.clicked += () => IncreaseUpgrade(UpgradeEnum.CRITICAL_SHOT);
        lessCriticalShotButton.clicked += () => DecreaseUpgrade(UpgradeEnum.CRITICAL_SHOT);
    }
    void UpTextLVL(UpgradeEnum upgradeEnum, int actual_level)
    {
        switch (upgradeEnum)
        {
            case UpgradeEnum.FIRERATE:
                fireRateTextLVL.text = actual_level.ToString();
                break;
            case UpgradeEnum.DAMAGE:

                break;
        }
    }
    void DownTextLVL(UpgradeEnum upgradeEnum, int actual_level)
    {
        switch (upgradeEnum)
        {
            case UpgradeEnum.FIRERATE:
                fireRateTextLVL.text = actual_level.ToString();
                break;
            case UpgradeEnum.DAMAGE:

                break;
        }
    }
    void Update()
    {

        // firerateLVL.text = perkManager.firerate_level.ToString();

        // Pausa o jogo, pausa parcial
        // TO FIX
        // Disparos pelo jogador ainda podem ser feitos
        // Rotacao do player ainda continua a seguir o mouse
        if (Input.GetKeyDown(KeyCode.P))
        {
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

    private void IncreaseUpgrade(UpgradeEnum upgrade)
    {
        OnUpgradeIncrease?.Invoke(upgrade);
    }
    private void DecreaseUpgrade(UpgradeEnum downgrade)
    {
        OnUpgradeDecrease?.Invoke(downgrade);
    }
}