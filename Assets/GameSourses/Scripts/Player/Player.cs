using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _firstWeapon;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;

    private Arsenal _arsenal;

    private float _afterShootTime;
    private int _currentHealth;
    private Animator _animator;
    private int _attackHash = Animator.StringToHash("Attack");

    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction MoneyChanged;
    public event UnityAction<Weapon> CurrentWeaponChanged;
    public event UnityAction NextWeaponChanged;
    public event UnityAction PreviousWeaponChanged;

    private void Awake()
    {
        _currentWeapon = _firstWeapon;
        _arsenal = new Arsenal();
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
        Money = 0;
    }

    private void Update()
    {
        if (_afterShootTime < _currentWeapon.Delay)
            _afterShootTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (_afterShootTime >= _currentWeapon.Delay)
            {
                _animator.SetTrigger(_attackHash);
                _currentWeapon.Shoot(_shootPoint);
                _afterShootTime = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _arsenal.GetPreviousWeapon(ref _currentWeapon);
            CurrentWeaponChanged?.Invoke(_currentWeapon);
            PreviousWeaponChanged?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _arsenal.GetNextWeapon(ref _currentWeapon);
            CurrentWeaponChanged?.Invoke(_currentWeapon);
            NextWeaponChanged?.Invoke();
        }
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Cost;
        MoneyChanged?.Invoke();
        _arsenal.TryAddWeapon(weapon);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            Die();
    }

    public void AddMoney(int reward)
    {
        Money += reward;
        MoneyChanged?.Invoke();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
