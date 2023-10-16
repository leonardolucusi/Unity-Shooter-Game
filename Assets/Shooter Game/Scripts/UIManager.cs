using UnityEngine;
using UnityEngine.UIElements;
public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject projectilePreFab;
    private Projectile projectileScript;
    private VisualElement root;
    private bool isUiVisible = true;
    private bool isPaused = false;
    Button speedUpgradeButton;
    VisualElement upgradeTab;
    public VisualTreeAsset uxmlFile1;
    public VisualTreeAsset uxmlFile2;
    private VisualElement currentVisualTree; 
    private UIDocument uiDocument;
    // PlayerManager playerController;
    void Start()
    {
        uiDocument = GetComponent<UIDocument>();
        // Carregue o Visual Tree inicial (por exemplo, uxmlFile1) ao iniciar o jogo
        LoadVisualTree(uxmlFile1);
        // playerController = player.GetComponent<PlayerManager>();
        projectileScript = projectilePreFab.GetComponent<Projectile>();
        root = GetComponent<UIDocument>().rootVisualElement;

        // upgradeTab =root.Q<VisualElement>("upgradeTab");
        // upgradeTab.visible = true;
        // speedUpgradeButton = root.Q<Button>("speedPlusUpgradeButton");
        // speedUpgradeButton.clicked += () => ProjectileSpeedUpgrade();
    }

     void LoadVisualTree(VisualTreeAsset visualTreeAsset)
    {
        if (currentVisualTree != null) currentVisualTree.RemoveFromHierarchy(); // Remova o Visual Tree atual (se houver)
        VisualElement newVisualTree = visualTreeAsset.CloneTree();
        GetComponent<UIDocument>().rootVisualElement.Add(newVisualTree);

        currentVisualTree = newVisualTree;
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
       
            if(isUiVisible){
                LoadVisualTree(uxmlFile2);
            }else{
                LoadVisualTree(uxmlFile1);
            }
            isUiVisible = !isUiVisible;
            // upgradeTab.visible = isUiVisible;
            // SetVisibilityRecursive(upgradeTab, isUiVisible);       
        }
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
    void ProjectileSpeedUpgrade(){
        projectileScript.IncreaseProjectileSpeed(10);
    }
    void ProjectileFireRateUpgrade(){
        projectileScript.IncreaseProjectileFireRate(1);
    }
    void ProjectileDamageUpgrade(){
        projectileScript.IncreaseProjectileDamage(1);
    }
   
}
