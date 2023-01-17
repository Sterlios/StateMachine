using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class WalkTransition : Transition
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) >= _enemy.AttackDistance)
            NeedTransit = true;
    }
}
