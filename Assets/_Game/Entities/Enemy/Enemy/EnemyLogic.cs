using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float life = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsBullet enemyScript = other.GetComponent<IsBullet>();

        if (enemyScript != null)
        {
            Destroy(other.gameObject);
            life--;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public bool IsAlive()
    {
        return life != 0;
    }
}
