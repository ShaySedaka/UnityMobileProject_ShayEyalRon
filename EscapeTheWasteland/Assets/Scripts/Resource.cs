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
    [SerializeField]
    private int _health = 5;

    [SerializeField]
    private ResourceType _type;

    public ResourceType Type { get => _type; }

    public void AttemptToMine(PlayerController player)
    {
        _health--;
        if (_health <= 0)
        {
            gameObject.SetActive(false);
            player.AddResourceToInventory(Type);
            
        }
    }
}
