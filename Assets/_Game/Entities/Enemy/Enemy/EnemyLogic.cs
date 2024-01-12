using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float colorCoolDown = 0.5f;
    public static float maxHealt = 100;
    private float life = maxHealt;
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
        life--;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
        life -= damage;
        _redColor = true;
        GetComponent<SpriteRenderer>().color = Color.red; 
        _colorClock = 0;
    }
    

    public bool IsAlive()
    {
        return life != 0;
    }
}
