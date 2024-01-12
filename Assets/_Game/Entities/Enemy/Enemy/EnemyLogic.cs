using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float colorCoolDown = 0.5f;
    [SerializeField] private float maxHealth = 100;

    private float _health;
    private float _colorClock;
    private bool _redColor;

    private void Awake()
    {
        _health = maxHealth;
    }

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
            if (enemyScript.FromBoss)
            {
                return;
            }
            
            Destroy(other.gameObject);
            TakeDamage(10);
        }
    }

    private void TakeDamage(int damage)
    {
        if (!IsAlive())
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        _health -= damage;
        _redColor = true;
        GetComponent<SpriteRenderer>().color = Color.red; 
        _colorClock = 0;
    }
    

    public bool IsAlive()
    {
        return _health > 0;
    }
}
