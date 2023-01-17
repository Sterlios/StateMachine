using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delay;
    [SerializeField] private int _cost;

    private bool _isBuyed = false;

    public string Name => _name;
    public Sprite Icon => _icon;
    public int Damage => _bullet.Damage;
    public float Delay => _delay;
    public int Speed => _bullet.Speed;
    public int Cost => _cost;
    public bool IsBuyed => _isBuyed;

    public virtual void Shoot(Transform transform)
    {
        Instantiate(_bullet, transform);
    }

    public void Buy()
    {
        _isBuyed = true;
    }
}
