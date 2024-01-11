using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] private RoundManagerScript[] rounds;
    private int _roundIndex = 0;

    private void Start()
    {

    }

    private void Update()
    {
        if (IsPlayerReady())
        {
            rounds[_roundIndex].SpawnEntities();
        }
        
    }

    private bool IsPlayerReady()
    {
        throw new NotImplementedException();
    }
}
