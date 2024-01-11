using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using BoxCollider2D = UnityEngine.BoxCollider2D;

public class portalZone : MonoBehaviour
{
    [SerializeField]
    private GameObject connectedPortal;

    
    private enum Direction
    {
        Right,
        Left,
        Down,
        Up
        
    }

    [SerializeField]
    private Direction exitDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BoxCollider2D portalBoxCollider = connectedPortal.GetComponent<BoxCollider2D>();
        BoxCollider2D otherBoxCollider = other.GetComponent<BoxCollider2D>();
        Rigidbody2D otherRigidbody2D = other.GetComponent<Rigidbody2D>();

        
        
        if (exitDirection == Direction.Right)
        {
            other.transform.position = new Vector3(
                connectedPortal.transform.position.x + (portalBoxCollider.bounds.size.x / 2) + (otherBoxCollider.size.x / 2) + 0.1f,
                connectedPortal.transform.position.y,
                0);
            otherRigidbody2D.velocity =
                new Vector2(Math.Abs(otherRigidbody2D.velocity.x), otherRigidbody2D.velocity.y);
        }
        
        if (exitDirection == Direction.Left)
        {
            other.transform.position = new Vector3(
                connectedPortal.transform.position.x - (portalBoxCollider.bounds.size.x / 2) - (otherBoxCollider.size.x / 2) - 0.1f,
               connectedPortal.transform.position.y,
                0);
            otherRigidbody2D.velocity =
                new Vector2(-Math.Abs(otherRigidbody2D.velocity.x), otherRigidbody2D.velocity.y);
        }
        
        if (exitDirection == Direction.Up)
        {
            other.transform.position = new Vector3(
                connectedPortal.transform.position.x ,
                connectedPortal.transform.position.y + (portalBoxCollider.bounds.size.y / 2) + (otherBoxCollider.size.y / 2) + 0.1f,
                0);
            otherRigidbody2D.velocity =
                new Vector2(otherRigidbody2D.velocity.x, Math.Abs( otherRigidbody2D.velocity.y));
        }
        
        if (exitDirection == Direction.Down)
        {
            other.transform.position = new Vector3(
                connectedPortal.transform.position.x ,
                connectedPortal.transform.position.y - (portalBoxCollider.bounds.size.y / 2) - (otherBoxCollider.size.y / 2) - 0.1f,
                0);
            otherRigidbody2D.velocity =
                new Vector2(otherRigidbody2D.velocity.x, -Math.Abs(otherRigidbody2D.velocity.y));
        }
    }
}
