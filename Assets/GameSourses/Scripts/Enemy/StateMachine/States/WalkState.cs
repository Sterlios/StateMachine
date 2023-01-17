using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WalkState : State
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private int _walkHash = Animator.StringToHash("isWalk");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Target != null)
           transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }

    public override void Enter(Player target)
    {
        _animator.SetBool(_walkHash, true);

        base.Enter(target);
    }

    public override void Exit()
    {
        _animator.SetBool(_walkHash, false);

        base.Exit();
    }
}
