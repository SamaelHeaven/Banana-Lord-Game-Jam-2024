using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZoneScript : MonoBehaviour
{

    public GameObject SpawnEntity(GameObject gameObject)
    {
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * 5;

        return Instantiate(gameObject, randomPosition, transform.rotation);
    }
}
