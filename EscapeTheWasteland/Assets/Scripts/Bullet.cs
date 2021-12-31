using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float _bulletSpeed = 3f;
    [SerializeField] int _bulletDamage = 0;

    private bool _fromPlayer = false;

    public int BulletDamage { get => _bulletDamage; set => _bulletDamage = value; }
    public bool FromPlayer { get => _fromPlayer; set => _fromPlayer = value; }

    void Start()
    {
        Destroy(gameObject, 3f);
    }


    void Update()
    {
        transform.position += transform.up * _bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag.Equals("Enemy") && FromPlayer)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(_bulletDamage);
        }

        else if (collision.gameObject.tag.Equals("Player") && !FromPlayer)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_bulletDamage);
        }

        Destroy(gameObject);
    }
}
