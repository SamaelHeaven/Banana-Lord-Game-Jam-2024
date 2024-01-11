using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        IsEnemy enemyScript = other.GetComponent<IsEnemy>();

        if (enemyScript != null)
        {
            Destroy(gameObject);
        }
    }
}
