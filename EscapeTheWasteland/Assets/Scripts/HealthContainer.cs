using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] GameObject _healthContainer;
    [SerializeField] GameObject _healthPack;

    static HealthContainer _instance;

    public static HealthContainer Instance
    {
        get
        {
            if(_instance == null)
                Debug.Log("HealthContainerIsNull");

            return _instance;
        }
    }
    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void DropHealth(Vector3 position, int healthAmount)
    {
        var pack = Instantiate(_healthPack, position, Quaternion.identity, _healthContainer.transform);
        pack.GetComponentInChildren<HealthPack>().SetHealthAmount(healthAmount);

    }
}
