using System.Collections.Generic;

public class PickAxe : Tool
{
    public float TimePerMineHit;

    public PickAxe()
    {
        _level = 0;
        TimePerMineHit = BalanceSettings.PickaxeMineSpeedByLevel[Level];
    }

    public override void Upgrade()
    {
        base.Upgrade();
        TimePerMineHit = (1f / (1f + (BalanceSettings.PickaxeMineSpeedByLevel[Level] / 100f)));
    }
}

