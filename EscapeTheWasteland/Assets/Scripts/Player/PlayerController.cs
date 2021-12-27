using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _runSpeed;

    [SerializeField] float _miningRadius = 1f;
    [SerializeField] LayerMask _miningLayerMask;
   
    [SerializeField] float _detectionRadius = 4f;

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] private ParticleSystem _miningEffect;
    [SerializeField] private GameObject _pickaxeSprite;
    [SerializeField] private GameObject _gunSprite;

    [SerializeField] private PlayerInventory _inventory;

    private Collider2D[] _collidersWithinRange;
   
    private float _timeSinceLastMine = 1;

    

    private GameObject _detectedEnemy;
    private float _timeToNextShot = 0f;

    public float RunSpeed { get => _runSpeed;}
    public PlayerInventory Inventory { get => _inventory; }

    void Update()
    {
        ScoutForEnemy();

        if(!_detectedEnemy)
        {
            StartCoroutine(PutGunAway());
            AttemptToMineResourcesAroundPlayer();
        }
        else
        {
            PullOutGun();
            LookAtEnemy();
            TryToShootEnemy();
        }      
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
        Gizmos.DrawWireSphere(transform.position, _miningRadius);
    }

   

    private void AttemptToMineResourcesAroundPlayer()
    {
        _timeSinceLastMine += Time.deltaTime;

        if(_timeSinceLastMine >= Inventory.Pickaxe.TimePerMineHit)
        {
            _collidersWithinRange = Physics2D.OverlapCircleAll(transform.position, _miningRadius, _miningLayerMask);

            if (_collidersWithinRange.Length > 0)
            {
                foreach (var collider in _collidersWithinRange)
                {
                    Resource resourceRef = collider.GetComponent<Resource>();
                    if (resourceRef != null && _inventory.Pickaxe.Level >= resourceRef.RequiredPickaxeLevelToMine)
                    {
                        resourceRef.AttemptToMine(this);
                        PullOutPickaxe();
                        _miningEffect.Play();
                    }
                    else
                    {
                        Debug.Log(collider.gameObject.name + " is Too Hard!");
                    }
                }

                _timeSinceLastMine = 0;
            }          
        }
    }

    public void AddResourceToInventory(ResourceType type)
    {
        if (Inventory.ResourceInventory.ContainsKey(type))
        {
            Inventory.ResourceInventory[type] += BalanceSettings.ResourcePerVein;       
        }

        //update UI manager
        UIManager.Instance.UpdateResourceText();
    }

    public void MovePlayer(Vector2 direction)
    {
        Vector3 v3Direction = new Vector3(direction.x, direction.y);
        transform.position += v3Direction * RunSpeed * Time.deltaTime;

        if (!_detectedEnemy)
        {
            RotatePlayer(v3Direction);
        }

    }

    public void RotatePlayer(Vector3 direction)
    {
        float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), 0.2f);

    }

    private void PullOutPickaxe()
    {
        _gunSprite.SetActive(false);
        _pickaxeSprite.SetActive(true);
        StartCoroutine(ReturnPickAxe());
    }

    private IEnumerator ReturnPickAxe()
    {
        yield return new WaitForSeconds(2f);
        _pickaxeSprite.SetActive(false);
    }

    private void PullOutGun()
    {
        _pickaxeSprite.SetActive(false);
        _gunSprite.SetActive(true);
    }

    private IEnumerator PutGunAway()
    {
        yield return new WaitForSeconds(1.5f);
        _gunSprite.SetActive(false);
    }

    private void ScoutForEnemy()
    {
        bool _wasEnemySpotted = false;

        Collider2D[] _collidersWithinRange = Physics2D.OverlapCircleAll(transform.position, _detectionRadius);
        foreach (Collider2D col in _collidersWithinRange)
        {
            if (col.tag.Equals("Enemy"))
            {
                _detectedEnemy = col.gameObject;
                _wasEnemySpotted = true;
                break;
            }
        }

        if(!_wasEnemySpotted)
        {
            _detectedEnemy = null;
        }
    }

    private void TryToShootEnemy()
    {
        _timeToNextShot -= Time.deltaTime;

        if (_timeToNextShot <= 0)
        {
            GameObject newBullet = Instantiate(_bulletPrefab, transform);
            newBullet.transform.parent = null;
            newBullet.SetActive(true);
            newBullet.GetComponent<Bullet>().BulletDamage = Inventory.Gun.GunPerShotDamage;
            newBullet.GetComponent<Bullet>().FromPlayer = true;

            _timeToNextShot = Inventory.Gun.FireRateInSeconds;
        }
    }

    private void LookAtEnemy()
    {
        Vector3 shotDirection = (_detectedEnemy.transform.position - gameObject.transform.position).normalized;
        RotatePlayer(shotDirection);
    }

}
