using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    
    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D _rigidbody;
    
    private float _direction;
    private bool _spacePressed;

    private void Update()
    {
        if (!_spacePressed)
        {
            _spacePressed = Input.GetButtonDown("Jump");
        }
    }

    private void RunFaster()
    {
        _spacePressed = false;
        _speed += (float) 0.5;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Vector2.right * _speed, ForceMode2D.Force);
        if (_spacePressed)
        {
            RunFaster();
        }
    }
}
