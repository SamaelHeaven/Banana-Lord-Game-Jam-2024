using UnityEngine;

public abstract class InteractableEntity : MonoBehaviour
{
    [SerializeField] protected PlayerMovement _player;
    [SerializeField] protected TakeDamage _playerHealth;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Animation _animation;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected CircleCollider2D _circleCollider;
    [SerializeField] protected ParticleSystem _particleSystem;
    [SerializeField] protected bool _can_interact;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindAnyObjectByType<PlayerMovement>();
        _playerHealth = FindAnyObjectByType<TakeDamage>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _audioSource = GetComponentInChildren<AudioSource>();
        _can_interact = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null)
        {
            return;
        }

        _spriteRenderer.flipX = _player.transform.position.x >= transform.position.x;

        if (_can_interact)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _particleSystem.Play();

                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                    _callBack();
                }
            }
        }
    }

    protected abstract void _callBack();
}
