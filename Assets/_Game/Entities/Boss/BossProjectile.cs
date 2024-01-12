using System;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 3.25f;

    public Vector3 Direction { get; set; }
    
    public float ShootingPower { get; set; }

    private void Start()
    {
        var velocity = (Direction * ShootingPower);
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity =  velocity;
        
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        // var towards = transform.forward * _speed * Time.deltaTime;
        // towards.z = 0;
        //
        // transform.position += towards;
        transform.Rotate (0, 0, 50 * Time.deltaTime * _rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<TakeDamage>(out var player))
        {
            player.takeDamage(15);
            Destroy(gameObject);
        }
    }
}
