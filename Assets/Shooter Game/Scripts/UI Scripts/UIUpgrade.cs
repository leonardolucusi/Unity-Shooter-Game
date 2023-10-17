using UnityEngine;
using UnityEngine.UIElements;
public class UIUpgrade : MonoBehaviour
{
    private GameObject projectile;
    private Projectile projectileScript;
    private VisualElement root;
    private bool isUiVisible = true;
    private bool isPaused = false;
    VisualElement upgradeTab;
    Button moreFireRateButton;
    Button lessFireRateButton;
    void Start()
    {
        projectile = Projectile.Instace.gameObject;
        projectileScript = projectile.GetComponent<Projectile>();
        root = GetComponent<UIDocument>().rootVisualElement;
        
        upgradeTab = root.Q<VisualElement>("upgradeTab");
        upgradeTab.visible = true;
        
        moreFireRateButton = root.Q<Button>("moreFireRateButton");
        lessFireRateButton = root.Q<Button>("lessFireRateButton");
        moreFireRateButton.clicked += () => MoreFireRate();
        lessFireRateButton.clicked += () => LessFireRate();

    }
    // Função recursiva para definir a visibilidade de todos os VisualElements e seus filhos
    void SetVisibilityRecursive(VisualElement element, bool isVisible)
    {
        element.visible = isVisible;

        for (int i = 0; i < element.childCount; i++)
        {
            VisualElement childElement = element.ElementAt(i);
            SetVisibilityRecursive(childElement, isVisible);
        }
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            isUiVisible = !isUiVisible;
            upgradeTab.visible = isUiVisible;
            SetVisibilityRecursive(upgradeTab, isUiVisible);
        }
        // Pausa o jogo, falta coisas
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
    void Speed(){
        projectileScript.IncreaseSpeed(10);
    }
    // FIRE RATE
    void LessFireRate(){
        projectileScript.DecreaseFireRate(1);
    }
    void MoreFireRate(){
        projectileScript.IncreaseFireRate(1);
    }
    // DAMAGE
    void Damage(){
        projectileScript.IncreaseDamage(1);
    }
}
