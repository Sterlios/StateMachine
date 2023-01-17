using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackDistanceSpread;

    private Player _target;
    private int _currentHealth;

    public float AttackDistance => _attackDistance;
    public Player Target => _target;
    public int Reward => _reward;
    public event UnityAction<Enemy> Dying;

    private void Start()
    {
        _attackDistance += Random.Range(-_attackDistanceSpread, _attackDistanceSpread);
        _currentHealth = _health;
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= Mathf.Abs(damage);

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        Dying.Invoke(this);
    }
}
