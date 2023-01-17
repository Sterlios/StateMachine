using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player Target { get; set; }

    public virtual void Enter(Player target)
    {
        if (!enabled)
        {
            Target = target;
            enabled = true;

            foreach(Transition transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public virtual void Exit()
    {
        if (enabled)
        {
            foreach (Transition transition in _transitions)
                transition.enabled = false;

            enabled = false;
            Debug.Log(enabled);
        }
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
            if (transition.NeedTransit)
                return transition.TargetState;

        return null;
    }
}
