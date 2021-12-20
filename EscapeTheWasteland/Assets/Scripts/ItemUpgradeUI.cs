using UnityEngine;

public class ItemUpgradeUI : MonoBehaviour
{
    [SerializeField]
    ResourceCostUI _woodUIHolder;
    [SerializeField]
    ResourceCostUI _stoneUIHolder;
    [SerializeField]
    ResourceCostUI _ironUIHolder;
    [SerializeField]
    ResourceCostUI _goldUIHolder;
    [SerializeField]
    ResourceCostUI _DiamondsUIHolder;
    private void Start()
    {
        SetUpgradeCost(0, 0, 0, 2, 500);
    }
    public void SetUpgradeCost(int woodAmount, int stoneAmount, int ironAmount, int goldAmount, int DiamondAmount)
    {
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
        if (goldAmount != 0)
        {
            _goldUIHolder.ActivateCost(goldAmount);
        }
        if (DiamondAmount != 0)
        {
            _DiamondsUIHolder.ActivateCost(DiamondAmount);
        }
    }
}
