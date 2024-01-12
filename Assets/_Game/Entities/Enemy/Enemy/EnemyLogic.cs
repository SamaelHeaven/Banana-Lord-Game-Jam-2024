using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float colorCoolDown = 0.5f;
    public static float maxHealth = 100;
    private float _health = maxHealth;
    private float _colorClock;
    private bool _redColor;

    private void Update()
    {
        _colorClock += Time.deltaTime;
        if (_redColor && _colorClock >= colorCoolDown)
        {
            _redColor = false;
            GetComponent<SpriteRenderer>().color = Color.white; 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsBullet enemyScript = other.GetComponent<IsBullet>();

        if (enemyScript != null)
        {
            Destroy(other.gameObject);
            TakeDamage(10);
        }
    }

    private void TakeDamage(int damage)
    {
        _health--;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
        _health -= damage;
        _redColor = true;
        GetComponent<SpriteRenderer>().color = Color.red; 
        _colorClock = 0;
    }
    

    public bool IsAlive()
    {
        return _health != 0;
    }
}
