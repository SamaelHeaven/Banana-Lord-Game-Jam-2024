using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] private RoundManagerScript[] rounds;
    [SerializeField] private CameraManager camera;
    private int _roundIndex = 0;

    private void Start()
    {
        camera.SwitchCamera(camera.bananaLordCamera);
        rounds[_roundIndex].SpawnEntities();
        
        
    }

    private void Update()
    {
        
    }

    // private bool IsPlayerReady()
    // {
    //     throw new NotImplementedException();
    // }
}
