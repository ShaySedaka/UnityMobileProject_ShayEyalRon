using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Tool
{

    private float _fireRateInSeconds;
    private int _gunPerShotDamage;
    
    public float FireRateInSeconds { get => _fireRateInSeconds; set => _fireRateInSeconds = value; }
    public int GunPerShotDamage { get => _gunPerShotDamage; set => _gunPerShotDamage = value; }

    public Gun(float fireRate, int gunDamage)
    {
        _fireRateInSeconds = fireRate;
        _gunPerShotDamage = gunDamage;
        _level = 0;
    }

    public override void Upgrade()
    {
        base.Upgrade();
        GunPerShotDamage = BalanceSettings.GunDamageByLevel[Level];
    }
}
