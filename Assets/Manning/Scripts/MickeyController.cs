using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MickeyController : InteractableEntity
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _can_interact = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _can_interact = false;
    }
}
