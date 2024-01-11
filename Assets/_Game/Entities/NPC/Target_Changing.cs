using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private float gridWidth;
    [SerializeField] private float gridHeight;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveDirection;
    
    private Transform currentTarget;
    
    private float timer = 0f;

    private void Start()
    {
        currentTarget = new GameObject("CurrentTarget").transform;
        SetRandomTarget();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        changeDestination();
    }

    private void changeDestination()
    {
        float distanceToTarget = Vector2.Distance(transform.position, currentTarget.position);
        
        if (distanceToTarget < 0.1f || timer >= Random.Range(20f, 40f))
        {
            SetRandomTarget();
            timer = 0f;
        }
    }

    private void SetRandomTarget()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-(gridWidth / 2), (gridWidth / 2)), Random.Range(-(gridHeight / 2), (gridHeight / 2)), 0f);
        currentTarget.position = randomPosition;
        
        AIDestinationSetter destinationSetter = gameObject.GetComponent<AIDestinationSetter>();

        if (destinationSetter != null)
        {
            destinationSetter.target = currentTarget;
        }
    }
}