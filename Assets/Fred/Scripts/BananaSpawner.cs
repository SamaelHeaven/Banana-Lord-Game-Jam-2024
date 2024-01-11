using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    private GameObject bananaPrefab;
    
    private float cooldown;
    private Random rnd;
    
    // Start is called before the first frame update
    void Start()
    {
        rnd = new Random();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (cooldown < 0)
        {
            cooldown = (float) (rnd.NextDouble() * 2) + 2 ;
            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            var banana =  Instantiate(bananaPrefab);
            Debug.Log(-(boxCollider2D.bounds.size.x / 2));
            banana.transform.position = new Vector3(  -(boxCollider2D.bounds.size.x / 2) +( (float) rnd.NextDouble() * boxCollider2D.bounds.size.x ),transform.position.y - (boxCollider2D.bounds.size.y / 2)  + ((float) rnd.NextDouble() * boxCollider2D.bounds.size.y) , 0f);
            Debug.Log("spawn: "+ banana.transform.position.x + " " + banana.transform.position.y);
        }
        else
        {
            cooldown -= Time.fixedDeltaTime;
        }
    }
    
    
}
