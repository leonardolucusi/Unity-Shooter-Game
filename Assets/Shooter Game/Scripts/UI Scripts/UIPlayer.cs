using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class UIPlayer : MonoBehaviour
{
    private GameObject player;
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
        metalScrapDisplay.text = ScoreManager.metalScrap.ToString();
    }
}
