using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCoinPlayer : MonoBehaviour
{
    private Transform coin;

    private void Awake()
    {
        if (TryGetComponent<PlayerMovement>(out var player))
        {
            
        }
    }

    private void Update()
    {
        
    }
}
