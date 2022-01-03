using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField]int _healthamount;
    public void SetHealthAmount(int healthAmount)
    {
        _healthamount = healthAmount;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().PickUpHealth(_healthamount);
            Destroy(gameObject);
        }
    }
}
