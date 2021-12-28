using UnityEngine;

public class UpgradeUIHandler : MonoBehaviour
{
    [SerializeField]
    ItemUpgradeUI _pickaxeUI;
    [SerializeField]
    ItemUpgradeUI _gunUI;
    [SerializeField]
    int _pickaxeMaxLevel;
    [SerializeField]
    int _gunMaxLevel;

    public void UpgradeItemLevels(int pickaxeLVL, int gunLVL)
    {
        if(pickaxeLVL < _pickaxeMaxLevel)
        {
            UpgradeCost pickaxeUpgradeCost = BalanceSettings.PickaxeUpgradeCosts[pickaxeLVL];
            _pickaxeUI.SetUpgradeCost(pickaxeUpgradeCost.WoodCost, pickaxeUpgradeCost.StoneCost, pickaxeUpgradeCost.IronCost, pickaxeUpgradeCost.CoalCost);
        }
        else
        {
            _pickaxeUI.gameObject.SetActive(false);
        }
        if(gunLVL < _gunMaxLevel)
        {
            UpgradeCost gunUpgradeCost = BalanceSettings.GunUpgradeCosts[gunLVL];
            _gunUI.SetUpgradeCost(gunUpgradeCost.WoodCost, gunUpgradeCost.StoneCost, gunUpgradeCost.IronCost, gunUpgradeCost.CoalCost);
        }
        else
        {
            _gunUI.gameObject.SetActive(false);
        }

        //get costs from the upgrade manager of some sort from level
    }
}
