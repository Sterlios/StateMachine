using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;
    private Animator _animator;
    private int _attackHash = Animator.StringToHash("isAttack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    public override void Enter(Player target)
    {
        _animator.SetBool(_attackHash, true);

        base.Enter(target);
    }

    public override void Exit()
    {
        _animator.SetBool(_attackHash, false);

        base.Exit();
    }

    private void Attack(Player target)
    {
        target.TakeDamage(_damage);
    }
}
