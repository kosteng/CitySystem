using UnityEngine;
using UnityEngine.AI;

public class UnitAnimation : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] NavMeshAgent _agent;
    private static readonly int Moving = Animator.StringToHash("Moving");

    private void FixedUpdate()
    {
        _animator.SetBool(Moving, _agent.hasPath);
    }

    //Placeholder functions for Animation events
    void Hit()
    {
    }

    void FootR()
    {
    }

    void FootL()
    {
    }
}