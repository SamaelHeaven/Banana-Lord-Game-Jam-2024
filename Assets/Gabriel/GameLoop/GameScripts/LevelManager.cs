using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int numberOfWaves = 5;
    [SerializeField] private float startDelay = 3f;
    [SerializeField] private float endDelay = 3f;
    [SerializeField] private Monster _monsterPrefab;

    private PlayerMovement _player;
    
    private WaitForSeconds startWait;
    private WaitForSeconds endWait;
    
    private int _waveCount = 1;
    private List<Monster> _currentWaveMonsters = new();
    
    private void Start()
    {
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);

        _player = FindObjectOfType<PlayerMovement>();
        
        StartCoroutine(HandleGameLoop());
    }
    
    private IEnumerator HandleGameLoop()
    {
        yield return StartCoroutine(HandleLevelStarting());
        yield return StartCoroutine(HandleLevelPlaying());
        yield return StartCoroutine(HandleLevelEnding());
    }
    
    private IEnumerator HandleLevelStarting()
    {
        yield return startWait;
    }
    
    private IEnumerator HandleLevelEnding()
    {
        yield return endWait;
    }

    private IEnumerator HandleLevelPlaying()
    {
        while (_waveCount != numberOfWaves) 
        {
            SpawnWave(_waveCount);

            while (AreEnemiesAlive())
            {
                yield return null;
            }
            
            _waveCount++;
        }
    }

    private bool AreEnemiesAlive()
    {
        return _currentWaveMonsters.Any(monster => monster.IsAlive);
    }

    private void SpawnWave(int waveCount)
    {
        _currentWaveMonsters.Clear();
        
        var playerPosition = _player.transform.position;

        if (waveCount == 1)
        {
            SpawnMonsterAtRandom(playerPosition, 2);
        } 
        else if (waveCount == 2)
        {
            SpawnMonsterAtRandom(playerPosition, 4);
        }
        else if (waveCount == 3)
        {
            SpawnMonsterAtRandom(playerPosition, 6);
        }
        else if (waveCount == 4)
        {
            SpawnMonsterAtRandom(playerPosition, 8);
        }
        else if (waveCount == 5)
        {
            SpawnMonsterAtRandom(playerPosition, 8);
        }
    }

    private void SpawnMonsterAtRandom(Vector3 playerPosition, int monsterCount)
    {
        for (int i = 0; i < monsterCount; ++i)
        {
            SpawnSphereOnEdgeRandomly3D(transform);
            // var monsterPosition = new Vector3(
            //     playerPosition.x + UnityEngine.Random.Range(-4, 4),
            //     playerPosition.y + UnityEngine.Random.Range(-4, 4),
            //     playerPosition.z);
            //var monster = Instantiate(_monsterPrefab, monsterPosition, _player.transform.rotation);
            // _currentWaveMonsters.Add(monster);
        }
    }
    
    private void SpawnSphereOnEdgeRandomly3D(Transform transform)
    {
        var radius = 10f;
        var randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;
        randomPos.y = 0f;
            
        var direction = randomPos - transform.position;
        direction.Normalize();
            
        var dotProduct = Vector3.Dot(transform.forward, direction);
        var dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);
            
        randomPos.x = Mathf.Cos(dotProductAngle) * radius + transform.position.x;
        randomPos.z = 0;
        randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * radius + transform.position.z;
            
        var monster = Instantiate(_monsterPrefab, randomPos, Quaternion.identity);
        monster.transform.position = randomPos;
        _currentWaveMonsters.Add(monster);
    }
}
