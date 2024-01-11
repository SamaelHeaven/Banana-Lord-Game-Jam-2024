using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZoneScript : MonoBehaviour
{

    public GameObject SpawnEntity(GameObject gameObject)
    {
        return Instantiate(gameObject, transform.position, transform.rotation);
    }
}
