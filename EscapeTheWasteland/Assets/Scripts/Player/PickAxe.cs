using System.Collections.Generic;

public class PickAxe
{
    private int _level;
    private Dictionary<int, UpgradeCost> _upgradeCosts = new Dictionary<int, UpgradeCost>();
    private Dictionary<int, float> _mineSpeedBonus = new Dictionary<int, float>();

    public float TimePerMineHit;
    public int Level { get => _level; set => _level = value; }
    public Dictionary<int, UpgradeCost> UpgradeCosts { get => _upgradeCosts; }

    public PickAxe()
    {
        _level = 0;
        TimePerMineHit = BalanceSettings.PickaxeMineSpeedByLevel[Level];
    }

    public void Upgrade()
    {
        Level++;
        TimePerMineHit = (1f / (1f + (BalanceSettings.PickaxeMineSpeedByLevel[Level] / 100f)));
    }
}

