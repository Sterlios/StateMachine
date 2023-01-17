using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber;
    private float _afterSpawnTime;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _afterSpawnTime += Time.deltaTime;

        if (_afterSpawnTime >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _afterSpawnTime = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.EnemyCount);
        }

        if (_currentWave.EnemyCount <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    public void StartNextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0; 
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.GetEnemy(), _spawnPosition.position, _spawnPosition.rotation, transform);
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _player.AddMoney(enemy.Reward);
    }
}

[System.Serializable]
public class Wave
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _delay;

    public float Delay => _delay;
    public int EnemyCount => _enemyCount;
    public Enemy GetEnemy() => _enemies[(int)Random.Range(0, (float)_enemies.Count)];
}