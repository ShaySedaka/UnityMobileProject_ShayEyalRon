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
       ResourceInventory.Add(ResourceType.Wood, 10);
       ResourceInventory.Add(ResourceType.Stone, 10);
       ResourceInventory.Add(ResourceType.Iron, 10);
       ResourceInventory.Add(ResourceType.Coal, 10);

       UIManager.Instance.UpdateResourceText();
    }

    private void AttemptToUpgradeTool(Tool tool, UpgradeCost nextUpgrade)
    {
        UpgradeCost currentResources = new UpgradeCost(ResourceInventory[ResourceType.Wood],
                                                       ResourceInventory[ResourceType.Stone],
                                                       ResourceInventory[ResourceType.Iron],
                                                       ResourceInventory[ResourceType.Coal]);

        if (currentResources >= nextUpgrade)
        {
            ResourceInventory[ResourceType.Wood] -= nextUpgrade.WoodCost;
            ResourceInventory[ResourceType.Stone] -= nextUpgrade.StoneCost;
            ResourceInventory[ResourceType.Iron] -= nextUpgrade.IronCost;
            ResourceInventory[ResourceType.Coal] -= nextUpgrade.CoalCost;
            tool.Upgrade();
            UIManager.Instance.UpdateResourceText();
            Debug.Log($"{tool.GetType()} level: " + tool.Level);
        }
    }

    public void AttemptToUpgradeGun()
    {
        UpgradeCost nextUpgrade = BalanceSettings.GunUpgradeCosts[Gun.Level + 1];
        AttemptToUpgradeTool(Gun, nextUpgrade);
        
    }

    public void AttemptToUpgradePickaxe()
    {
        UpgradeCost nextUpgrade = BalanceSettings.PickaxeUpgradeCosts[Pickaxe.Level + 1];
        AttemptToUpgradeTool(Pickaxe, nextUpgrade);
    }
}
