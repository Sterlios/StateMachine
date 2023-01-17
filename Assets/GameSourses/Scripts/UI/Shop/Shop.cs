using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private WeaponShopCell _cell;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _container;

    private void Start()
    {
        foreach (Weapon weapon in _weapons)
            AddItem(weapon);
    }

    private void AddItem(Weapon weapon)
    {
        var item = Instantiate(_cell, _container.transform);
        item.SellButtonClick += OnSellButtonClick;
        item.Render(weapon);
    }

    private void OnSellButtonClick(Weapon weapon, WeaponShopCell cell)
    {
        TrySellWeapon(weapon, cell);
    }

    private void TrySellWeapon(Weapon weapon, WeaponShopCell cell)
    {
        if(weapon.Cost <= _player.Money)
        {
            Debug.Log("tutu");
            _player.BuyWeapon(weapon);
            weapon.Buy();
            cell.SellButtonClick -= OnSellButtonClick;
        }
    }
}
