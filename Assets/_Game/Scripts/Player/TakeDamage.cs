using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class TakeDamage : MonoBehaviour
{
    private static float maxHealth = 100;
    private float health = maxHealth;
    [SerializeField] private float coolDownTime;
    [SerializeField] private float colorCoolDown;
    private HealthBar _healthBar;
    private float _clock;
    private float _colorClock;
    private bool _redColor;

    private void Start()
    {
        _healthBar = GameObject.Find("HealthBar").GetComponentInChildren<HealthBar>();
        
    }

    private void Update()
    {
        _healthBar.SetValue(Mathf.Max(0, health / maxHealth));
        _clock += Time.deltaTime;
        _colorClock += Time.deltaTime;
        if (_redColor && _colorClock >= colorCoolDown)
        {
            _redColor = false;
            GameObject.Find("Player Sprite").GetComponent<SpriteRenderer>().color = Color.white; 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsEnemy enemyScript = other.GetComponent<IsEnemy>();
        if (enemyScript == null)
        {
           return; 
        }
        takeDamage(10);
    }

    public void takeDamage(int damage)
    {
        if (_clock > coolDownTime)
        {
            GameObject.Find("HitSound").GetComponent<AudioSource>().Play();
            health -= damage;
            _redColor = true;
            GameObject.Find("Player Sprite").GetComponent<SpriteRenderer>().color = Color.red;
            _clock = 0;
            _colorClock = 0;
        }
    }
}

