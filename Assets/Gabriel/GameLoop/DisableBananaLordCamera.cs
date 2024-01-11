using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBananaLordCamera : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            levelManager.SwitchCameraBackToPlayer();
        }
    }
}
