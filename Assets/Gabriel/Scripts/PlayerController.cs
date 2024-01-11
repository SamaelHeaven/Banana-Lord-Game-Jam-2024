using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Properties")] 
    
    [SerializeField] private Vector2 velocity = new (7, 7);
    [SerializeField] private Rigidbody2D body;

    private Vector2 _movement;

    private PlayerInputActionsTopDown _inputActions;

    private void Awake()
    {
        _inputActions = new PlayerInputActionsTopDown();
        _inputActions.Player.Enable();
    }

    private void Update()
    {
        _movement = _inputActions.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }
        
    private void MoveCharacter()
    {
        var movement = _movement * velocity * Time.deltaTime;
        body.MovePosition(body.position + movement);
    }
}
