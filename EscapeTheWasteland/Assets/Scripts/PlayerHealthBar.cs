using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Slider _slider;

    public void SetHealth(float health, float maxHealth)
    {
        _slider.gameObject.SetActive(true);
        _slider.maxValue = maxHealth;
        _slider.value = health;
        

    }
}
