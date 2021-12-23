using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int _hp = 10;


    public void TakeDamage(int damage)
    {
        Debug.Log("Player hit with damage: " + damage);

        _hp -= damage;

        if (_hp <= 0)
        {
            OnPlayerDeath();
        }
    }

    private void OnPlayerDeath()
    {
        // restart the scene
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
