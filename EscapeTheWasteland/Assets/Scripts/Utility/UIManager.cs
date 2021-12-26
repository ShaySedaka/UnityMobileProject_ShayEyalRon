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
    [SerializeField] public TextMeshProUGUI _diamondsText;


    public void InitializeAllTexts()
    {
        _woodText.text = "0";
        _stoneText.text = "0";
        _ironText.text = "0";
        _goldText.text = "0";
        _diamondsText.text = "0";
    }

    public void UpdateResourceText(int wood, int stone, int iron, int diamonds)
    {
        _woodText.text = wood.ToString();
        _stoneText.text = stone.ToString();
        _ironText.text = iron.ToString();
        _diamondsText.text = diamonds.ToString();
    }
}
