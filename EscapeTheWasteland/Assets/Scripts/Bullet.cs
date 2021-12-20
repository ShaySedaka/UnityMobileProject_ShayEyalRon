using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float _bulletSpeed = 3f;
    [SerializeField] int _bulletDamage = 0;

    public int BulletDamage { get => _bulletDamage; set => _bulletDamage = value; }


    void Start()
    {
        StartCoroutine(DestroyAfterSecs(3f));
    }


    void Update()
    {
        transform.position += transform.up * _bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag.Equals("Player")) return;

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(_bulletDamage);
        }

        Destroy(gameObject);
    }


    public IEnumerator DestroyAfterSecs(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
