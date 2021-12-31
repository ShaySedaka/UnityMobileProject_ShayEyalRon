using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class BalanceSettings
{
    public static UpgradeCost[] GunUpgradeCosts = { new UpgradeCost(7, 5, 0, 0), 
                                                    new UpgradeCost(8, 5, 4, 0),
                                                    new UpgradeCost(11, 8, 9, 0) };


    public static UpgradeCost[] PickaxeUpgradeCosts = { new UpgradeCost(10, 0, 0, 0),
                                                        new UpgradeCost(12, 7, 0, 0),
                                                        new UpgradeCost(10, 10, 10, 0) };

    public static int[] GunDamageByLevel = { 2, 3, 4, 5 };

    public static float[] PickaxeMineSpeedByLevel = { 0, 50f, 100f, 150f };

    public static float GunFireRate = 0.6f;

    public static int ResourcePerVein = 3;

}

