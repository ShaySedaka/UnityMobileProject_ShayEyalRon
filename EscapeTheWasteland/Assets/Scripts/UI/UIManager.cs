using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private GameObject _winLoseCanvas;
    

    [SerializeField] public TextMeshProUGUI _woodText;
    [SerializeField] public TextMeshProUGUI _stoneText;
    [SerializeField] public TextMeshProUGUI _ironText;
    [SerializeField] public TextMeshProUGUI _goldText;
    [SerializeField] public TextMeshProUGUI _coalText;
    




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
        _woodText.text = _playerInventory.ResourceInventory[ResourceType.Wood].ToString();
        _stoneText.text = _playerInventory.ResourceInventory[ResourceType.Stone].ToString();
        _ironText.text = _playerInventory.ResourceInventory[ResourceType.Iron].ToString();
        _coalText.text = _playerInventory.ResourceInventory[ResourceType.Coal].ToString();
    }

    public void TurnOffUpgradeCanvas()
    {
        _upgradeCanvas.SetActive(false);
    }

    public void TurnOnWinCanvas()
    {
        Time.timeScale = 0;
        _winLoseCanvas.SetActive(true);
        _winLoseCanvas.GetComponent<WinLoseCanvas>().SetWinData();
    }

    public void TurnOnLoseCanvas()
    {
        Time.timeScale = 0;
        _winLoseCanvas.SetActive(true);
        _winLoseCanvas.GetComponent<WinLoseCanvas>().SetLoseData();
    }
}
