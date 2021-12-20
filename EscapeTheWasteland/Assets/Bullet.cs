using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float _bulletSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterSecs(3f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * _bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag.Equals("Player")) return;

        Destroy(gameObject);
    }


    public IEnumerator DestroyAfterSecs(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
