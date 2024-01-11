using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animation _animation;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private bool _can_pet;

    void Start()
    {
        _player = FindAnyObjectByType<PlayerMovement>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _audioSource = GetComponentInChildren<AudioSource>();
        _can_pet = false;
    }

    void Update()
    {
        if (_player == null)
        {
            return;
        }

        _spriteRenderer.flipX = _player.transform.position.x >= transform.position.x;
        
        if (_can_pet)
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                
                    _particleSystem.Play();
                    _audioSource.Play();
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.speed = 12f;
        _can_pet = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animator.speed = 2f;
        _can_pet = false;
    }
}
