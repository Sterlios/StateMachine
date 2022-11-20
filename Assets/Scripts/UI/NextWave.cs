using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawn _spawn;
    [SerializeField] private Button _nextWaveButton;

    private void OnEnable()
    {
        _spawn.AllEnemySpawned += OnAllEnemySpawned;
        _nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawn.AllEnemySpawned -= OnAllEnemySpawned;
        _nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    private void OnAllEnemySpawned()
    {
        _nextWaveButton.gameObject.SetActive(true);
    }

    private void OnNextWaveButtonClick()
    {
        _spawn.StartNextWave();
        _nextWaveButton.gameObject.SetActive(false);
    }
}
