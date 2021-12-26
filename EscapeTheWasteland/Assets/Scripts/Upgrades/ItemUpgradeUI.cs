using UnityEngine;

public class ItemUpgradeUI : MonoBehaviour
{
    [SerializeField]
    ResourceCostUI _woodUIHolder;
    int _woodCost;
    [SerializeField]
    ResourceCostUI _stoneUIHolder;
    int _stoneCost;
    [SerializeField]
    ResourceCostUI _ironUIHolder;
    int _ironCost;
    [SerializeField]
    ResourceCostUI _coalUIHolder;
    int _coalCost;
    public void SetUpgradeCost(int woodAmount, int stoneAmount, int ironAmount, int DiamondAmount)
    {
        _woodCost = woodAmount;
        _stoneCost = stoneAmount;
        _ironCost = ironAmount;
        _coalCost = DiamondAmount;

        if(woodAmount != 0 )
        {
            _woodUIHolder.ActivateCost(woodAmount);
        }
        if (stoneAmount != 0)
        {
            _stoneUIHolder.ActivateCost(stoneAmount);
        }
        if (ironAmount != 0)
        {
            _ironUIHolder.ActivateCost(ironAmount);
        }
        if (DiamondAmount != 0)
        {
            _coalUIHolder.ActivateCost(DiamondAmount);
        }
    }
    public void OnUpgrade()
    {
        //if player has enough resources than use them and upgrade item;
    }

    
}
