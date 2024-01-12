using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireDelay;
    [SerializeField] private AudioSource shootSound;
    private float _fireClock;

    private void Update()
    {
        if (_fireClock < fireDelay)
        {
            _fireClock += Time.deltaTime;
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!PlayerActivator.flag)
            {
                return;
            }
            _fireClock = 0;
            FireBullet();
        }
    }

    private void FireBullet()
    {
        var platformCenter = transform.position;
        var launchDirection = transform.rotation * Vector3.right;
        var projectile = Instantiate(bulletPrefab, platformCenter, Quaternion.identity);
        projectile.transform.rotation = transform.rotation;
        projectile.GetComponent<SpriteRenderer>().flipY = GetComponent<SpriteRenderer>().flipY;
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = launchDirection * bulletSpeed;
        shootSound.Play();
    }

    public void IncreaseSpeed(float speed)
    {
        fireDelay = Mathf.Max(0, fireDelay - speed);
    }
}
