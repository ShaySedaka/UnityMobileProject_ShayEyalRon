using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PickAxe _pickAxe;
    private Gun _gun;
    private Dictionary<ResourceType, int> _resourceInventory = new Dictionary<ResourceType, int>();

    public Dictionary<ResourceType, int> ResourceInventory { get => _resourceInventory; }
    public Gun Gun { get => _gun; set => _gun = value; }
    public PickAxe Pickaxe { get => _pickAxe; set => _pickAxe = value; }

    // Start is called before the first frame update
    void Start()
    {
        Pickaxe = new PickAxe();
        Gun = new Gun(BalanceSettings.GunFireRate, BalanceSettings.GunDamageByLevel[0]);
        InitializeResourceInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeResourceInventory()
    {
       ResourceInventory.Add(ResourceType.Wood, 0);
       ResourceInventory.Add(ResourceType.Stone, 0);
       ResourceInventory.Add(ResourceType.Iron, 0);
       ResourceInventory.Add(ResourceType.Coal, 0);

        UIManager.Instance.InitializeAllTexts();
    }
}
