using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeapon : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.CurrentWeaponChanged += OnCurrentWeaponChanged;
    }

    private void OnDisable()
    {
        _player.CurrentWeaponChanged -= OnCurrentWeaponChanged;
    }

    private void OnCurrentWeaponChanged(Weapon weapon)
    {
        _icon.sprite = weapon.Icon;
    }
}
