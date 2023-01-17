using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private float _startValue = 1;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        Initialize(_startValue);
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }
}
