using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger)
        {
            return;
        }
        
        Destroy(gameObject);
    }
}
