using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Wood,
    Stone,
    Iron,
    Coal
}

public class Resource : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHP = 5;

    [SerializeField] HealthbarBehavior _healthbar;

    [SerializeField]
    private ResourceType _type;

    [SerializeField]
    private int _requiredPickaxeLevelToMine = 1;

    public ResourceType Type { get => _type; }
    public int RequiredPickaxeLevelToMine { get => _requiredPickaxeLevelToMine;}


    private void Start()
    {
        _health = _maxHP;
        _healthbar.SetHealth(_health, _maxHP);
    }

    public void AttemptToMine(PlayerController player)
    {
        _health--;
        _healthbar.SetHealth(_health, _maxHP);
        if (_health <= 0)
        {
            gameObject.SetActive(false);
            player.AddResourceToInventory(Type);
            
        }
    }
}
