using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private float minDistanceFromSpawner;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRateIncreaseDelay;
    [SerializeField] private float spawnRateIncreaseAmount;
    private float _spawnRateClock;
    private float _spawnRateIncreaseClock;

    private void Update()
    {
        UpdateSpawn();
        UpdateSpawnRate();
    }

    private void UpdateSpawn()
    {
        _spawnRateClock += Time.deltaTime;
        if (_spawnRateClock > spawnRate)
        {
            _spawnRateClock = 0;
            SpawnTarget();
        }
    }

    private void UpdateSpawnRate()
    {
        _spawnRateIncreaseClock += Time.deltaTime;
        if (_spawnRateIncreaseClock > spawnRateIncreaseDelay)
        {
            _spawnRateIncreaseClock = 0;
            spawnRate = Mathf.Max(0.5f, spawnRate - spawnRateIncreaseAmount);
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
            randomPosition += (minDistanceFromSpawner - distanceToSpawner) *
                              (randomPosition - transform.position).normalized;
        }

        Instantiate(targetPrefab, randomPosition, Quaternion.identity);
    }
}