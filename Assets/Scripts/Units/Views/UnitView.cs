using UnityEngine;
using UnityEngine.AI;

namespace Units.Views
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class UnitView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private LayerMask _movementMask;
        public void MoveToPoint(Vector3 point) 
        {
            _agent.SetDestination(point);
        }
    
        public void Refresh(Camera camera) 
        {
            if (Input.GetMouseButtonDown(1)) 
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f, _movementMask)) 
                {
                    MoveToPoint(hit.point);
                }
            }

            if (Input.GetMouseButtonDown(0)) 
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f)) 
                {
                    MoveToPoint(hit.point);
                }
            }
        }
    }
}
