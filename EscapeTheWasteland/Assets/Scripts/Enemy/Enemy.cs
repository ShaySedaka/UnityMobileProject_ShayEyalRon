using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public enum EnemyState
{
    IDLE,
    COMBAT
}

public class Enemy : MonoBehaviour
{ 
    [SerializeField] int _hp = 5;
    [SerializeField] float _fireRateInSeconds = 0.6f;
    [SerializeField] float _detectionRadius = 20f;
    [SerializeField] int _bulletDamage = 1;

    [SerializeField] GameObject _alertEffect;
    [SerializeField] GameObject _bulletPrefab;

    private EnemyState _currentState;
    private GameObject _detectedPlayer;
    private float _timeToNextShot;

    // Start is called before the first frame update
    void Start()
    {
        _currentState = EnemyState.IDLE;
        _timeToNextShot = _fireRateInSeconds;
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }


    // Update is called once per frame
    void Update()
    {
        UpdateEnemyState();

        switch (_currentState)
        {
            case EnemyState.IDLE:
                OnIdle();
                break;

            case EnemyState.COMBAT:
                OnCombat();
                break;
        }        
    }


    private void RotateEnemy(Vector3 direction)
    {
        float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), 0.1f);
    }


    private void OnCombat()
    {
        //get pure shot direction by vector subtraction
        _alertEffect.SetActive(true);
        Vector3 shotDirection = (_detectedPlayer.transform.position - gameObject.transform.position).normalized;
        RotateEnemy(shotDirection);

        ShootIfPossible();


    }

    private void OnIdle()
    {
        _alertEffect.SetActive(false);
        
    }

    private void ShootIfPossible()
    {
        _timeToNextShot -= Time.deltaTime;

        if(_timeToNextShot <= 0)
        {
            GameObject newBullet = Instantiate(_bulletPrefab, transform);
            newBullet.transform.parent = null;
            newBullet.SetActive(true);
            newBullet.GetComponent<Bullet>().BulletDamage = _bulletDamage;

            _timeToNextShot = _fireRateInSeconds;
        }
    }

    private void UpdateEnemyState()
    {

        bool _wasPlayerSpotted = false;

        Collider2D[] _collidersWithinRange = Physics2D.OverlapCircleAll(transform.position, _detectionRadius);
        foreach (Collider2D col in _collidersWithinRange)
        {
            if (col.tag.Equals("Player"))
            {
                _detectedPlayer = col.gameObject;
                _wasPlayerSpotted = true;
                break;
            }
        }

        if (_wasPlayerSpotted)
        {
            _currentState = EnemyState.COMBAT;
        }
        else
        {
            _currentState = EnemyState.IDLE;
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy hit with damage: " + damage);

        _hp -= damage;

        if(_hp <= 0)
        {
            OnEnemyDeath();
        }
    }

    private void OnEnemyDeath()
    {
        gameObject.SetActive(false);
    }
}
