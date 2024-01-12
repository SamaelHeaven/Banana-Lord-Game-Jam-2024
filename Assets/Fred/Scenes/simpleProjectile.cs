using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class simpleProjectile : MonoBehaviour
{
    [SerializeField] private float lifeSpan = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        lifeSpan -= Time.fixedDeltaTime;
        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<TakeDamage>(out var player))
        {
            player.takeDamage(15);
            Destroy(gameObject);
        }
        
    }
}
