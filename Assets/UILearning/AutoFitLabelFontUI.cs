using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
public class AutoFitLabelFontUI : MonoBehaviour
{
    VisualElement root;
    VisualElement navBar;
    Button resizeLabelsButton;
    public int maxFontSize = 40;
    public int minFontSize = 10;
    int fontSize;
    void Start(){
        root = GetComponent<UIDocument>().rootVisualElement;
        navBar = root.Q<VisualElement>("navBar");
        resizeLabelsButton = root.Q<Button>("resizeLabelsButton");
        resizeLabelsButton.clicked += () => ResizeText();
    }
    void Update()
    {  
    }

    void ResizeText()
{
    int largestFontSize = 0;
    // Calcular o tamanho do texto apenas uma vez com base no primeiro elemento da navBar
    int baseFontSize = CalculateFontSize(navBar[0].resolvedStyle.width, navBar[0].resolvedStyle.height);

    for (int i = 0; i < navBar.childCount; i++)
    {
        // Definir o tamanho do texto para todos os elementos com o tamanho calculado anteriormente
        navBar[i].style.fontSize = baseFontSize;

        if (baseFontSize >= largestFontSize)
        {
            largestFontSize = baseFontSize;
        }
    }

    for (int i = 0; i < navBar.childCount; i++)
    {
        // Definir o maior tamanho de fonte para todos os elementos
        navBar[i].style.fontSize = largestFontSize;
        print(navBar[i].style.fontSize);
    }
}

    int CalculateFontSize(float labelWidth, float labelHeight)
    {
        int fontSize = Mathf.RoundToInt(labelWidth / 10f + labelHeight / 10);
        fontSize = Mathf.Clamp(fontSize, minFontSize, maxFontSize);
        return fontSize;
    }
}