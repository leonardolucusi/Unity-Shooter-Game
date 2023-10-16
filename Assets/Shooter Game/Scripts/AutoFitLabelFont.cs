using UnityEngine;
using UnityEngine.UIElements;

public class AutoFitLabelFont : MonoBehaviour
{
    private VisualElement root;
    public Label label;
    public int maxFontSize = 40;
    public int minFontSize = 10;
    
    void Update()
    {
        
        // root = GetComponent<UIDocument>().rootVisualElement;
        // label = root.Q<Label>("projectileSpeedLabel");
        // int fontSize = CalculateFontSize(label.resolvedStyle.width);
        // label.style.fontSize = fontSize;
    }

    int CalculateFontSize(float labelWidth)
    {
        int fontSize = Mathf.RoundToInt(labelWidth / 10f);
        fontSize = Mathf.Clamp(fontSize, minFontSize, maxFontSize);
        return fontSize;
    }
}
