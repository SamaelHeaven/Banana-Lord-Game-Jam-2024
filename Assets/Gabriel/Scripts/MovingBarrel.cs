using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBarrel : MonoBehaviour
{
    private float _moveSpeed = 5.0f;

    void Update()
    {
        transform.position += (Vector3.left * _moveSpeed) * Time.deltaTime;
        
        if (transform.position.x < -20) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<PlayerPv>(out var player)) {
            player.dropPv();
            Destroy(gameObject);
        }
    }
}
