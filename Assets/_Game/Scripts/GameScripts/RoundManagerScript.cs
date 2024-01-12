using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoundManagerScript : MonoBehaviour
{
    [SerializeField] private SpawnZoneScript[] spawnZones;
    [SerializeField] private int numberOfEntityToSpawn;
    [SerializeField] private GameObject[] entityToSpawn;
    private List<GameObject> entities { get; } = new ();

    public List<GameObject> SpawnEntities()
    {
        int spawnZonesIndex = 0;
        for (int i = 0; i < numberOfEntityToSpawn; i++)
        {
            int randomEntityIndex = Random.Range(0, entityToSpawn.Length);
            entities.Add(spawnZones[spawnZonesIndex].SpawnEntity(entityToSpawn[randomEntityIndex]));
            spawnZonesIndex++;
            if (spawnZonesIndex >= spawnZones.Length)
            {
                spawnZonesIndex = 0;
            }
        }

        return entities;
    }

    public void DeleteEntity(GameObject enemy)
    {
        entities.Remove(enemy);
    }
    
}
