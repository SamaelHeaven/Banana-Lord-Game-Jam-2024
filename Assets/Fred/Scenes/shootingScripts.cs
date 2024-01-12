using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public class shootingScripts : MonoBehaviour
{

    [SerializeField] 
    private int bulletSpeed = 3;
    
    [SerializeField]
    private float attackDistance;

    [SerializeField]
    private GameObject bulletPrefabs;

    private Random rnd;
    private float cooldown = 2f;
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
        if (cooldown > 0)
        {
            cooldown -= Time.fixedDeltaTime;
            return;
        }

        var player = GameObject.Find("Player");
        var playerPosition = player.transform.position;
        var distanceFromPlayer = Mathf.Abs(Vector3.Distance(playerPosition, transform.position));
        if (distanceFromPlayer <= attackDistance)
        {
            shoot(player);
        }
    }

    private void shoot(GameObject player)
    {
        cooldown = 2.5f;
        
        float distanceX = player.transform.position.x - transform.position.x;
        float distanceY = player.transform.position.y - transform.position.y;
        float distanceTotale = Math.Abs(distanceX) + Math.Abs(distanceY);
        float VelocityX = distanceX * bulletSpeed / distanceTotale ;
        float VelocityY = distanceY * bulletSpeed / distanceTotale ;

        var bullet = Instantiate(bulletPrefabs);
        bullet.transform.position = gameObject.transform.position;
        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
        bulletBody.velocity = (new Vector2(VelocityX, VelocityY));
        
        if (distanceY < 0)
        {
            bullet.transform.Rotate(0, 0,
                Vector2.Angle(new Vector2(distanceX, distanceY),
                    new Vector2(transform.position.x, transform.position.y)));
        }
        else
        {
            bullet.transform.Rotate(0, 0,
                -Vector2.Angle(new Vector2(distanceX, distanceY),
                    new Vector2(transform.position.x, transform.position.y)));
        }
    }
}
