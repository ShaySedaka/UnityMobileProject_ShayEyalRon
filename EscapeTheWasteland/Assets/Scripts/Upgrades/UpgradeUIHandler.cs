using UnityEngine;

public class UpgradeUIHandler : MonoBehaviour
{
    [SerializeField]
    ItemUpgradeUI _pickaxeUI;
    [SerializeField]
    ItemUpgradeUI _gunUI;

    public void UpgradeItemLevels(int pickaxeLVL, int gunLVL)
    {
        UpgradeCost gunUpgradeCost = BalanceSettings.GunUpgradeCosts[gunLVL];
        UpgradeCost pickaxeUpgradeCost = BalanceSettings.PickaxeUpgradeCosts[pickaxeLVL];

        //get costs from the upgrade manager of some sort from level
        _pickaxeUI.SetUpgradeCost(pickaxeUpgradeCost.WoodCost, pickaxeUpgradeCost.StoneCost, pickaxeUpgradeCost.IronCost, pickaxeUpgradeCost.CoalCost);
        _gunUI.SetUpgradeCost(gunUpgradeCost.WoodCost, gunUpgradeCost.StoneCost, gunUpgradeCost.IronCost, gunUpgradeCost.CoalCost);
    }
}
