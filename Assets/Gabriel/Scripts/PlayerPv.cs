using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPv : MonoBehaviour
{
    private int pv { get; set; } = 4;

    private void Update()
    {
        if (pv <= 0)
        {
            Debug.Log("Player is dead!");
        }
    }

    public void dropPv()
    {
        pv -= 1;
    }
}
