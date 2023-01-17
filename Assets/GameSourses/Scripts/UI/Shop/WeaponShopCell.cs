using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponShopCell : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _bulletSpeed;
    [SerializeField] private TMP_Text _delay;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Button _sellButton;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponShopCell> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        _name.text = weapon.Name;
        _icon.sprite = weapon.Icon;
        _damage.text = weapon.Damage.ToString();
        _bulletSpeed.text = weapon.Speed.ToString();
        _delay.text = weapon.Delay.ToString();
        _cost.text = weapon.Cost.ToString();
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }

    private void TryLockItem()
    {
        if (_weapon.IsBuyed)
        {
            _sellButton.interactable = false;
        }
    }
}
