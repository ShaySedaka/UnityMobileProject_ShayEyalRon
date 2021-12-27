using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public TextMeshProUGUI _woodText;
    [SerializeField] public TextMeshProUGUI _stoneText;
    [SerializeField] public TextMeshProUGUI _ironText;
    [SerializeField] public TextMeshProUGUI _goldText;
    [SerializeField] public TextMeshProUGUI _coalText;
    [SerializeField] private PlayerInventory playerInventory;


    public void InitializeAllTexts()
    {
        _woodText.text = "0";
        _stoneText.text = "0";
        _ironText.text = "0";
        _goldText.text = "0";
        _coalText.text = "0";
    }

    public void UpdateResourceText()
    {
        _woodText.text = playerInventory.ResourceInventory[ResourceType.Wood].ToString();
        _stoneText.text = playerInventory.ResourceInventory[ResourceType.Stone].ToString();
        _ironText.text = playerInventory.ResourceInventory[ResourceType.Iron].ToString();
        _coalText.text = playerInventory.ResourceInventory[ResourceType.Coal].ToString();
    }
}
