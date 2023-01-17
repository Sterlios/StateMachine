using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private Animator _animator;
    private int _celebrationHash = Animator.StringToHash("isCelebration");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Enter(Player target)
    {
        _animator.SetBool(_celebrationHash, true);

        base.Enter(target);
    }

    public override void Exit()
    {
        _animator.SetBool(_celebrationHash, false);

        base.Exit();
    }
}
