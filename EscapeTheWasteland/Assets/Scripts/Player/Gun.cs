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

    public Gun(float fireRate, int gunDamage)
    {
        _fireRateInSeconds = fireRate;
        _gunPerShotDamage = gunDamage;
        _level = 0;
    }

    public void Upgrade()
    {
        Level++;
        GunPerShotDamage = BalanceSettings.GunDamageByLevel[Level];
    }
}
