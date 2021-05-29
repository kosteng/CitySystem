using Characters;
using Engine.Mediators;
using Units.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Units.Controllers
{
    public class CharacterMovementController : IUpdatable, IInitializable
    {
        private readonly CharacterView _characterView;
        private Camera _mainCamera;
        private ECharacterState _characterCurrentState;
        private const int LEFT_MOUSE_BUTTON = 1;
        private bool _isMoving;
        private Vector3 _pointDestination;
        private static readonly int Moving = Animator.StringToHash("Moving");
        public Transform UnitViewTransform => _characterView.transform;

        public CharacterMovementController(CharacterView characterView)
        {
            //todo нужна фабрика
            if (_characterView == null)
                _characterView = Object.Instantiate(characterView);
        }

        public void Update(float deltaTime)
        {
            CheckTargetForMove(_mainCamera);
            CheckStopState();
            UpdateAnimation();
        }

        private void CheckTargetForMove(Camera camera)
        {
            if (!Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON)) return;

            var ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 100f) && !EventSystem.current.IsPointerOverGameObject())
            {
                MoveToPoint(hit.point);
            }
        }

        public void Initialize()
        {
            _mainCamera = Camera.main;
        }

        private void MoveToPoint(Vector3 point)
        {
            _characterView.transform.LookAt(point);
            _pointDestination = point;
            _characterView.NavMeshAgent.SetDestination(_pointDestination);
        }

        private void CheckStopState()
        {
            _isMoving = _characterView.NavMeshAgent.remainingDistance > _characterView.NavMeshAgent.stoppingDistance;
            _characterView.NavMeshAgent.isStopped = !_isMoving;
        }
        private void UpdateAnimation()
        {

            _characterView.Animator.SetBool(Moving, _isMoving);
        }
    }
}