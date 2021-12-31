using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _maxHP = 10;
    [SerializeField] int _hp;

    private void Start()
    {
        _hp = _maxHP;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player hit with damage: " + damage);

        _hp -= damage;

        if (_hp <= 0)
        {
            OnPlayerDeath();
        }
    }
    public void PickUpHealth(int health)
    {
        _hp += health;
        if(_hp >= _maxHP)
            _hp = _maxHP;
        Debug.Log($"player health is {_hp}");
    }

    private void OnPlayerDeath()
    {
        UIManager.Instance.TurnOnLoseCanvas();
    }
}
