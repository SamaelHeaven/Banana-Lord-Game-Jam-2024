using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class PickRandomSpeed : MonoBehaviour
{
    public float upperBound;
    public float lowerBound;
    
    void Start()
    {
        GetComponent<AIPath>().maxSpeed = Random.Range(lowerBound, upperBound);
    }
}
