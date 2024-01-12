using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MickeyController : InteractableEntity
{
    //hurt
    protected override void _callBack()
    {
        int random = Random.Range(1, 10);
        _playerHealth.takeDamage(random);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _can_interact = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _can_interact = false;
    }
}
