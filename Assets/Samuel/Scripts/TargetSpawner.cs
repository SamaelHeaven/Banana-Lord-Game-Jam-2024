using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private float minDistanceFromSpawner;
    [SerializeField] private float spawnRate;
    private float _spawnClock;

    private void Update()
    {
        _spawnClock += Time.deltaTime;
        if (_spawnClock > spawnRate)
        {
            _spawnClock = 0;
            SpawnTarget();
        }
    }

    private void SpawnTarget()
    {
        var main = Camera.main;
        var cameraHeight = main.orthographicSize;
        var cameraWidth = cameraHeight * main.aspect;
        var randomX = Random.Range(-cameraWidth, cameraWidth);
        var randomY = Random.Range(-cameraHeight, cameraHeight);
        var position = transform.position;
        var randomPosition = new Vector3(randomX, randomY, 0f) + position;
        var distanceToSpawner = Vector3.Distance(position, randomPosition);
        if (distanceToSpawner < minDistanceFromSpawner)
        { 
            randomPosition += (minDistanceFromSpawner - distanceToSpawner) * (randomPosition - transform.position).normalized;
        }
        Instantiate(targetPrefab, randomPosition, Quaternion.identity);
    }
}