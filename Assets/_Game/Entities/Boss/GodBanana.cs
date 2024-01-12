using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GodBanana : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _stopChaseAtRadius = 3f;
    
    [SerializeField] private Transform _projectileSpawner;
    [SerializeField] private BossProjectile _projectilePrefab;
    [SerializeField] private float _shootingPower = 1.85f;

    private SpriteRenderer _renderer;
    private GameObject _player;
    private Vector3 newPosition;

    private const float ShootBananaCooldown = 1f;
    private float _lastShootBananaTime;
    
    private const float SpecialAttackCooldown = 2f;
    private float _lastSpecialAttackTime;
    
    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var chance = UnityEngine.Random.value;
        if (_lastSpecialAttackTime >= SpecialAttackCooldown && chance < 0.025f)
        {
            DoSpecialAttack();
        }
        else if (_lastShootBananaTime >= ShootBananaCooldown && chance < 0.25f)
        {
            ShootBananas();
        }
        else if (chance < 0.40f)
        {
            // Do nothing a bit
        }
        else 
        {
            if (Vector2.Distance(transform.position, _player.transform.position) > _stopChaseAtRadius) 
            {
                MoveTowards(_player.transform);
            }
            else if (_lastSpecialAttackTime >= SpecialAttackCooldown)
            {
                DoSpecialAttack();
            }
        }

        LookAt(_player.transform);

        _lastShootBananaTime += Time.deltaTime;
        _lastSpecialAttackTime += Time.deltaTime;
    }

    private void DoSpecialAttack()
    {
        _lastSpecialAttackTime = 0f;
        StartCoroutine(SpecialAttack());
    }

    private IEnumerator SpecialAttack()
    {
        var oldColor = _renderer.color;
        _renderer.color = Color.red;
        yield return new WaitForSeconds(1.5f);
        _renderer.color = oldColor;
        
        var numberOfAttacks = UnityEngine.Random.Range(12, 18);
        var angle = 30;
        if (numberOfAttacks != 0)
        {
            angle = (360 / numberOfAttacks);
        }
        
        var shootingPower = UnityEngine.Random.Range(_shootingPower - 0.25f, _shootingPower + 0.15f);
        
        for (var i = 1; i <= numberOfAttacks; i++)
        {
            var projectile = Instantiate(
                _projectilePrefab,
                transform.position,
                transform.rotation);
            projectile.Direction = Quaternion.Euler(0, 0, angle * i) * (_player.transform.position - transform.position);
            projectile.ShootingPower = shootingPower;
            projectile.GetComponent<IsBullet>().FromBoss = true;
        }
    }


    private void LookAt(Transform target)
    {
        var diff = (target.position - transform.position).normalized;
        if (diff.x > 0)
        {
            Flip(-1);
        }
        else
        {
            Flip(1);
        }
    }

    private void Flip(int scaleX)
    {
        var localScale = transform.localScale;
        localScale = new Vector3(scaleX, localScale.y, localScale.z);
        transform.localScale = localScale;
    }

    private void ShootBananas()
    {
        _lastShootBananaTime = 0f;

        var isTripleShot = (UnityEngine.Random.value < 0.5f);
        var shootingPower = isTripleShot ? 
                UnityEngine.Random.Range(_shootingPower - 0.45f, _shootingPower) : 
                UnityEngine.Random.Range(_shootingPower - 0.25f, _shootingPower + 0.325f);
        
        var projectile = Instantiate(_projectilePrefab, _projectileSpawner.position, _projectileSpawner.rotation);
        projectile.ShootingPower = shootingPower;
        projectile.Direction = _player.transform.position - transform.position;
        projectile.GetComponent<IsBullet>().FromBoss = true;
        
        if (isTripleShot)
        {
            const float offset = 0.75f;
            var projectile2 = Instantiate(
                _projectilePrefab,
                new Vector3(_projectileSpawner.position.x, _projectileSpawner.position.y + offset, _projectileSpawner.position.z),
                _projectileSpawner.rotation);
            projectile2.Direction = Quaternion.Euler(0, 0, -15) * (_player.transform.position - transform.position);
            projectile2.ShootingPower = shootingPower;
            projectile2.GetComponent<IsBullet>().FromBoss = true;

            var projectile3 = Instantiate(
                _projectilePrefab,
                new Vector3(_projectileSpawner.position.x, _projectileSpawner.position.y - offset, _projectileSpawner.position.z),
                _projectileSpawner.rotation);
            projectile3.Direction = Quaternion.Euler(0, 0, +15) * (_player.transform.position - transform.position);
            projectile3.ShootingPower = shootingPower;
            projectile3.GetComponent<IsBullet>().FromBoss = true;
        }
    }

    private void MoveTowards(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }
}
