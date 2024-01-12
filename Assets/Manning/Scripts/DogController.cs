using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : InteractableEntity
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _can_interact = true;
        _animator.speed = 12f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _can_interact = false;
        _animator.speed = 2f;
    }
}
