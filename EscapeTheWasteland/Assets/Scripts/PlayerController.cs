using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _runSpeed;

    [SerializeField]
    private int _pickAxeLevel;

    private Collider2D[] _collidersWithinRange;

    Dictionary<ResourceType, int> _resourceInventory = new Dictionary<ResourceType, int>();

    private float _timeSinceLastMine = 1;

    private PickAxe _pickAxe;

    // Start is called before the first frame update
    void Start()
    {
        InitializeResourceInventory();

        foreach (var resource in _resourceInventory)
        {
            Debug.Log(resource.Key.ToString() + ": " + resource.Value);
        }

        _pickAxe = new PickAxe();
        _pickAxe.Level = _pickAxeLevel;
        _pickAxe.InitializePickaxe();
    }

    // Update is called once per frame
    void Update()
    {
        MineResourcesAroundPlayer();
    }

    private void InitializeResourceInventory()
    {
        
        _resourceInventory.Add(ResourceType.Wood, 0);
        _resourceInventory.Add(ResourceType.Stone, 0);
        _resourceInventory.Add(ResourceType.Iron, 0);
        _resourceInventory.Add(ResourceType.Gold, 0);
        _resourceInventory.Add(ResourceType.Oil, 0);
    }

    private void MineResourcesAroundPlayer()
    {
        _timeSinceLastMine += Time.deltaTime;

        if(_timeSinceLastMine >= _pickAxe.TimePerAttack)
        {
            _collidersWithinRange = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x / 2);

            if (_collidersWithinRange.Length > 0)
            {
                // Play Animation
                foreach (var collider in _collidersWithinRange)
                {
                    Resource resourceRef = collider.GetComponent<Resource>();
                    if (((int)resourceRef.Type) <= _pickAxe.Level)
                    {
                        
                        resourceRef.AttemptToMine(this);
                        Debug.Log("Ding!");
                    }
                    else
                    {
                        Debug.Log("Too Hard!");
                    }
                    
                    
                }

                _timeSinceLastMine = 0;
            }
        }
    }

    public void AddResourceToInventory(ResourceType type)
    {
        if(_resourceInventory.ContainsKey(type))
        {
            _resourceInventory[type] += 3;
            Debug.Log( type.ToString() + ": " + _resourceInventory[type] );
        }
    }

    public void MovePlayer(Vector2 direction)
    {
        Vector3 v3Direction = new Vector3(direction.x, direction.y);

        transform.position += v3Direction * _runSpeed * Time.deltaTime;

        RotatePlayer(v3Direction);

    }

    public void RotatePlayer(Vector3 direction)
    {
        float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }



}
