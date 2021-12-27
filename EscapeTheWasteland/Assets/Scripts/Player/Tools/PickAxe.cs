using System.Collections.Generic;

public class PickAxe : Tool
{
    public float TimePerMineHit;

    public PickAxe()
    {
        _level = 0;
        TimePerMineHit = (1f / (1f + (BalanceSettings.PickaxeMineSpeedByLevel[Level] / 100f)));
    }

    public override void Upgrade()
    {
        base.Upgrade();
        TimePerMineHit = (1f / (1f + (BalanceSettings.PickaxeMineSpeedByLevel[Level] / 100f)));
    }
}

