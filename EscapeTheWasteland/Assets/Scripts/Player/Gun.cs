using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun 
{

    private float _fireRateInSeconds;
    private int _gunPerShotDamage;
    private int _level;
    private Dictionary<int, UpgradeCost> _upgradeCosts = new Dictionary<int, UpgradeCost>();

    public int Level { get => _level; set => _level = value; }
    public float FireRateInSeconds { get => _fireRateInSeconds; set => _fireRateInSeconds = value; }
    public int GunPerShotDamage { get => _gunPerShotDamage; set => _gunPerShotDamage = value; }
    public Dictionary<int, UpgradeCost> UpgradeCosts { get => _upgradeCosts; }

    private Dictionary<int, float> _damageUpgrades = new Dictionary<int, float>();

    public Gun()
    {
        _fireRateInSeconds = 0.6f;
        _gunPerShotDamage = 1;
        _level = 0;
    }

    public void InitializeGun()
    {
        InitializeUpgradeTree();
    }

    public void InitializeUpgradeTree()
    {
        _damageUpgrades.Add(1, 2);
        UpgradeCosts.Add(0, new UpgradeCost(1, 0, 0, 0));

        _damageUpgrades.Add(2, 3);
        UpgradeCosts.Add(1, new UpgradeCost(0, 1, 0, 0));

        _damageUpgrades.Add(3, 4);
        UpgradeCosts.Add(2, new UpgradeCost(0, 0, 1, 0));
    }
}
