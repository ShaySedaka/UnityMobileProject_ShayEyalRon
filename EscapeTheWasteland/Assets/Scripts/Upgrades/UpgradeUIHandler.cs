using UnityEngine;

public class UpgradeUIHandler : MonoBehaviour
{
    [SerializeField]
    ItemUpgradeUI _pickaxeUI;
    [SerializeField]
    ItemUpgradeUI _gunUI;

    public void UpgradeItemLevels(int pickaxeLVL, int gunLVL)
    {
        //get costs from the upgrade manager of some sort from level
        _pickaxeUI.SetUpgradeCost(0, 0, 0, 1, 1);
        _gunUI.SetUpgradeCost(1, 2, 10, 0, 0);
    }
}
