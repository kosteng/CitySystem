using UnityEngine;
using UnityEngine.AI;


namespace Units.Views
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;
        public NavMeshAgent NavMeshAgent => _agent;
        public Animator Animator => _animator;
    }
}