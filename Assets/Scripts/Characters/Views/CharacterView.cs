using UnityEngine;
using UnityEngine.AI;


namespace Units.Views
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Animator _animator;

        private bool _isMoving;
        private Vector3 _pointDestination;
        private static readonly int Moving = Animator.StringToHash("Moving");
        public NavMeshAgent NavMeshAgent => _agent;

        public void MoveToPoint(Vector3 point)
        {
            transform.LookAt(point);
            _pointDestination = point;
            _agent.SetDestination(_pointDestination);
        }

        private void FixedUpdate()
        {
            _isMoving = _agent.remainingDistance > _agent.stoppingDistance;
            _agent.isStopped = !_isMoving;
            _animator.SetBool(Moving, _isMoving);
        }
    }
}