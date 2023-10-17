using UnityEngine;
using UnityEngine.UIElements;
public class UIUpgrade : MonoBehaviour
{
    public GameObject projectile;
    public ProjectileSO projectileSO;
    private Projectile projectileScript;
    private VisualElement root;
    private bool isPaused = false;
    VisualElement upgradeTab;
    Button moreFireRateButton;
    Button lessFireRateButton;
    Button moreSpeedButton;
    void Start()
    {
        projectileScript = projectile.GetComponent<Projectile>();
        root = GetComponent<UIDocument>().rootVisualElement;
        
        upgradeTab = root.Q<VisualElement>("upgradeTab");
        upgradeTab.visible = true;
        
        moreFireRateButton = root.Q<Button>("moreFireRateButton");
        lessFireRateButton = root.Q<Button>("lessFireRateButton");
        moreFireRateButton.clicked += () => MoreFireRate();
        lessFireRateButton.clicked += () => LessFireRate();

        moreSpeedButton = root.Q<Button>("moreSpeedButton");
        moreSpeedButton.clicked += () => MoreSpeed();

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
    // SPEED
    void MoreSpeed(){
        projectileSO.speed += 10;
        Debug.Log("More speed button pressed");
    }
    // FIRE RATE
    void LessFireRate(){
    }
    void MoreFireRate(){
    }
    // DAMAGE
    void Damage(){
    }
}
