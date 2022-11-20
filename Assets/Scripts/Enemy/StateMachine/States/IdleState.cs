using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IdleState : State
{
    private Animator _animator;
    private int _idleHash = Animator.StringToHash("isIdle");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Enter(Player target)
    {
        _animator.SetBool(_idleHash, true);

        base.Enter(target);
    }

    public override void Exit()
    {
        _animator.SetBool(_idleHash, false);

        base.Exit();
    }
}
