using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private Spawn _spawn;

    private float _startValue = 0;

    private void OnEnable()
    {
        _spawn.EnemyCountChanged += OnValueChanged;
        Initialize(_startValue);
    }

    private void OnDisable()
    {
        _spawn.EnemyCountChanged -= OnValueChanged;
    }
}
