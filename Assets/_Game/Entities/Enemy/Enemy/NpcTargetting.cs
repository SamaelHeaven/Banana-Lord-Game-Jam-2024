using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class NpcTargetting : MonoBehaviour
{
    private void Awake()
    {
        GameObject player = FindObjectOfType<PlayerMovement>().gameObject;
        AIDestinationSetter destinationSetter = gameObject.GetComponent<AIDestinationSetter>();

        
        if (destinationSetter != null)
        {
            Debug.Log("Go to player");
            destinationSetter.target = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
