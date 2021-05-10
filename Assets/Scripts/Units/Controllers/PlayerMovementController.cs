using Engine.Mediators;
using Units.Views;
using UnityEngine;
using Zenject;

namespace Units.Controllers
{
    public class PlayerMovementController : IUpdatable, IInitializable
    {
        private readonly UnitView _unitView;
        private Camera _mainCamera;

        public Transform UnitViewTransform => _unitView.transform;

        public PlayerMovementController(UnitView unitView)
        {
            //todo нужна фабрика
            if (_unitView == null)
                _unitView = MonoBehaviour.Instantiate(unitView);
        }

        public void StopUnit()
        {
            _unitView.NavMeshAgent.Stop(); 
        }
        
        public void Update(float deltaTime)
        {
            PlayerMove(_mainCamera);
        }

        private void PlayerMove(Camera camera)
        {
            if (Input.GetMouseButtonDown(1))
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit, 100f, _unitView.MovementMask))
                {
                    _unitView.MoveToPoint(hit.point);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f))
                {
 
                }
            }
        }

        public void Initialize()
        {
            _mainCamera = Camera.main;
        }
    }
}