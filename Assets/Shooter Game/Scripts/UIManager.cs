using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public VisualElement uiContainer; 
    private bool uiVisible = false;
    private VisualElement root;
    Button button;
    PlayerManager playerController;
    void Start()
    {    
        playerController = player.GetComponent<PlayerManager>();

        root = GetComponent<UIDocument>().rootVisualElement;
        button = root.Q<Button>("button");
        button.clicked += () => ButtonClicked();
    }
    void FixedUpdate(){
    
    }
    void ButtonClicked(){
        playerController.IncreaseProjectileSpeed(1);
        Debug.Log(playerController.projectileSpeed);
    }
}
