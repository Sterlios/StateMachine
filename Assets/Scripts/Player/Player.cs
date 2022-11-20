using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapon _currentWeapon;

    private float _afterShootTime;
    private int _currentHealth;
    private Animator _animator;
    private int _attackHash = Animator.StringToHash("Attack");

    public int Money { get; private set; }

    private void Awake()
    {
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_afterShootTime < _currentWeapon.Delay)
            _afterShootTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if(_afterShootTime >= _currentWeapon.Delay)
            {
                _animator.SetTrigger(_attackHash);
                _currentWeapon.Shoot();
                _afterShootTime = 0;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddMoney(int reward)
    {
        Money += reward;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
