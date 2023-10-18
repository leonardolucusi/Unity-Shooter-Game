using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private VisualElement uiUpgradeRoot;
    private bool isUiVisible = true;
    void Start()
    {
        uiUpgradeRoot = transform.Find("UIUpgrade").gameObject.GetComponent<UIDocument>().rootVisualElement;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            isUiVisible = !isUiVisible;
            uiUpgradeRoot.visible = isUiVisible;
            SetVisibilityRecursive(uiUpgradeRoot, isUiVisible);
        }
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
}
