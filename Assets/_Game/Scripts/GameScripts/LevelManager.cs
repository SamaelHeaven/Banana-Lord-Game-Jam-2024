using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private RoundManagerScript[] rounds;
    [SerializeField] private CameraManager camera;

    [SerializeField] private int numberOfWaves = 5;
    [SerializeField] private float startDelay = 3f;
    [SerializeField] private float endDelay = 3f;
    [FormerlySerializedAs("_monsterPrefab")] [SerializeField] private Enemy _enemyPrefab;

    private PlayerMovement _player;
    
    private WaitForSeconds startWait;
    private WaitForSeconds endWait;
    
    private int _waveCount = 0;
    private List<GameObject> _currentWaveMonsters = new();
    
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
            SpawnWave();

            while (AreEnemiesAlive())
            {
                yield return null;
            }
            
            _waveCount++;
        }
    }

    private bool AreEnemiesAlive()
    {
        return _currentWaveMonsters.Any(go =>
        {
            var enemy = go.GetComponent<Enemy>();
            return enemy.IsAlive();
        });
    }

    private void SpawnWave()
    {
        _currentWaveMonsters.Clear();
        
        camera.SwitchCamera(camera.bananaLordCamera);
        _currentWaveMonsters = rounds[_waveCount].SpawnEntities();
    }

    public void SwitchCameraBackToPlayer()
    {
        camera.SwitchCamera(camera.playerCamera);
    }
}
