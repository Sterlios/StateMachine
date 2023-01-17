using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Player Target { get; private set; }
    public bool NeedTransit { get; protected set; }
    public State TargetState => _targetState;
    private void OnEnable()
    {
        NeedTransit = false;
    }
    public void Init(Player target)
    {
        Target = target;
    }
}
