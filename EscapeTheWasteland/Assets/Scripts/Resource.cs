using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Wood,
    Stone,
    Iron,
    Gold, 
    Oil
}

public class Resource : MonoBehaviour
{
    private int _health;

    [SerializeField]
    private ResourceType _type;

    public ResourceType Type { get => _type; }



    // Start is called before the first frame update
    void Start()
    {
        _health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttemptToMine(PlayerController player)
    {
        _health--;
        if (_health <= 0)
        {
            player.AddResourceToInventory(Type);
            Destroy(gameObject);
        }
    }
}
