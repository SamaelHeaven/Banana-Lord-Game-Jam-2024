using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _velocity;
    private Animator _animator;

    private void Start()
    {
        // You might want to make sure that the Animator is attached to the same GameObject as this script
        _animator = GameObject.Find("Player Sprite").GetComponent<Animator>();
    }

    private void Update()
    {
        ProcessInputs();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        if (!PlayerActivator.flag)
        {
            return;
        }
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");
        _velocity = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        rb.velocity = new Vector2(_velocity.x * speed, _velocity.y * speed);
    }

    private void UpdateAnimation()
    {
        if (_velocity != Vector2.zero)
        {
            // Determine the direction of movement and play the corresponding animation
            if (Mathf.Abs(_velocity.x) > Mathf.Abs(_velocity.y))
            {
                // Horizontal movement
                if (_velocity.x > 0)
                    _animator.Play("Player_Run_Right");
                else
                    _animator.Play("Player_Run_Left");
            }
            else
            {
                // Vertical movement
                if (_velocity.y > 0)
                    _animator.Play("Player_Run_Top");
                else
                    _animator.Play("Player_Run_Bottom");
            }
        }
        else
        {
            // If not moving, play the idle animation based on the last movement direction
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Run_Right"))
                _animator.Play("Player_Right");
            else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Run_Left"))
                _animator.Play("Player_Left");
            else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Run_Top"))
                _animator.Play("Player_Top");
            else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Run_Bottom"))
                _animator.Play("Player_Bottom");
        }
    }

    public void IncreaseSpeed(float speedBonus)
    {
        speed += speedBonus;
    }
}