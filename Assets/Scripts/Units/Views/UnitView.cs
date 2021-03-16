using UnityEngine;
using UnityEngine.AI;

namespace Units.Views
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class UnitView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private LayerMask _movementMask;

        public LayerMask MovementMask => _movementMask;

        public void MoveToPoint(Vector3 point) 
        {
            _agent.SetDestination(point);
        }
    }
}
