using System.Collections.Generic;

public class PickAxe
{
    private int _level;
    private Dictionary<int, UpgradeCost> _upgradeCosts = new Dictionary<int, UpgradeCost>();

    public int Level { get => _level; set => _level = value; }

    private Dictionary<int, float> _mineSpeedBonus = new Dictionary<int, float>();

    public float TimePerMineHit { get => (1f / (1f + (_mineSpeedBonus[Level]/100f))); }

    public Dictionary<int, UpgradeCost> UpgradeCosts { get => _upgradeCosts; }

    public void InitializePickaxe()
        {
            InitializeUpgradeTree();
        }
        
    public void InitializeUpgradeTree()
    {
        _mineSpeedBonus.Add(0, 0);
        

        _mineSpeedBonus.Add(1, 20f);
        _upgradeCosts.Add(1, new UpgradeCost(1,0,0,0));

        _mineSpeedBonus.Add(2, 50f);
        _upgradeCosts.Add(2, new UpgradeCost(0, 1, 0, 0));

        _mineSpeedBonus.Add(3, 100f);
        _upgradeCosts.Add(3, new UpgradeCost(0, 0, 1, 0));

        _mineSpeedBonus.Add(4, 100f);
        _upgradeCosts.Add(4, new UpgradeCost(0, 0, 0, 1));
    }
}

