using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerInputActionsPlatformer _inputActions;

    [SerializeField] private float speed = 5f;
    [SerializeField] private bool canMove = true;
    [SerializeField] private float jumpForce = 4.5f;

    private bool isGrounded; // Indique si le joueur est au sol

    private void Awake()
    {
        _inputActions = new PlayerInputActionsPlatformer();
        _inputActions.Player.Enable();

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (canMove)
        {
            Vector2 movement = _inputActions.Player.Move.ReadValue<Vector2>();
            _rigidbody.velocity = new Vector2(movement.x * speed, _rigidbody.velocity.y);
        }
    }

    private void Jump()
    {
        if (_inputActions.Player.Jump.triggered && isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // Mettez à jour l'état du sol après le saut
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}