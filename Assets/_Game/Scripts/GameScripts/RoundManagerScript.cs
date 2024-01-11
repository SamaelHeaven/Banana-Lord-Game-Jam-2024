using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundManagerScript : MonoBehaviour
{
    [SerializeField] private SpawnZoneScript[] spawnZones;
    [SerializeField] private int numberOfEntityToSpawn;
    [SerializeField] private GameObject entityToSpawn;
    private List<GameObject> _entities { get; } = new ();

    public List<GameObject> SpawnEntities()
    {
        int spawnZonesIndex = 0;
        for (int i = 0; i < numberOfEntityToSpawn; i++)
        {
            _entities.Add(spawnZones[spawnZonesIndex].SpawnEntity(entityToSpawn));
            spawnZonesIndex++;
            if (spawnZonesIndex >= spawnZones.Length)
            {
                spawnZonesIndex = 0;
            }
        }

        return _entities;
    }

    public void DeleteEntity(GameObject enemy)
    {
        _entities.Remove(enemy);
    }
    
}
