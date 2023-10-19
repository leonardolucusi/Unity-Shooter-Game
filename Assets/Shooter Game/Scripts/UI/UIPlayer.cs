using UnityEngine;
using UnityEngine.UIElements;

public class UIPlayer : MonoBehaviour
{
    private GameObject player;
    public CollectableSO collectableSO;
    VisualElement root;
    Label metalScrapDisplay;
    void Start()
    {
        player = PlayerManager.Instance.gameObject;
        root = GetComponent<UIDocument>().rootVisualElement;

        metalScrapDisplay = root.Q<Label>("metalScrapDisplay");
    }
    void Update()
    {
        metalScrapDisplay.text = collectableSO.metalScrap.ToString();
    }
}
