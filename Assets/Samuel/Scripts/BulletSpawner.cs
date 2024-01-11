using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireDelay;
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
            _fireClock = 0;
            FireBullet();
        }
    }

    private void FireBullet()
    {
        var position = transform.position;
        var platformCenter = position;
        var mousePosition = Input.mousePosition;
        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, position.z));
        var launchDirection = worldMousePosition - platformCenter;
        var length = Mathf.Sqrt(launchDirection.x * launchDirection.x + launchDirection.y * launchDirection.y);
        launchDirection = new Vector3(launchDirection.x * bulletSpeed / length, launchDirection.y * bulletSpeed / length, 0f);
        var projectile = Instantiate(bulletPrefab, platformCenter, Quaternion.identity);
        var projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = launchDirection;
    }
}
