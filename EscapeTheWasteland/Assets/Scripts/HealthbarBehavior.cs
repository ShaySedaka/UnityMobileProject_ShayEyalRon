using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehavior : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] Vector3 _offset;

    void Update()
    {
        _slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        _slider.gameObject.SetActive(health < maxHealth);
        _slider.value = health;
        _slider.maxValue = maxHealth;

    }
}
