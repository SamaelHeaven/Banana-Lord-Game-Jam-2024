using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _barrel;
    private float spawnRate = 2.0f;
    private float timer = 0;

    private void Start()
    {
        SpawnBarrel();
    }

    private void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnBarrel();
            timer = 0;
            spawnRate = Random.Range(1.0f, 5.0f);
        }
        
    }

    private void SpawnBarrel()
    {
        Instantiate(_barrel, transform.position, transform.rotation);
    }
}
