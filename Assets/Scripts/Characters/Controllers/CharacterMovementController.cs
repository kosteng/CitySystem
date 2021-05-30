using Characters;
using Engine.Mediators;
using Units.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


public enum ECharacterCommand
{
    None,
    Interact,
    Move
}


namespace Units.Controllers
{
    public class CharacterMovementController : IUpdatable, IInitializable
    {
        private readonly CityDatabase _cityDatabase;
        private static readonly int Moving = Animator.StringToHash("Moving");
        private readonly CharacterView _characterView;
        private Camera _mainCamera;
        private ECharacterState _characterCurrentState = ECharacterState.Idle;
        private ECharacterCommand _characterCommand = ECharacterCommand.None;
        private const int LEFT_MOUSE_BUTTON = 1;
        private bool _isMoving;
        private Vector3 _pointDestination;
        private IInteractableItem _interactableItemTarget;
        public Transform UnitViewTransform => _characterView.transform;

        public CharacterMovementController(CharacterView characterView, CityDatabase cityDatabase)
        {
            _cityDatabase = cityDatabase;
            //todo нужна фабрика
            if (_characterView == null)
                _characterView = Object.Instantiate(characterView);
        }

        public void Update(float deltaTime)
        {
            CheckTargetForMove(_mainCamera);
            CheckInteract();
            CheckStopState();
            UpdateAnimation();
            SetMovementState();
            Extract();
        }

        private void CheckTargetForMove(Camera camera)
        {
            if (!Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON)) return;

            var ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 100f) && !EventSystem.current.IsPointerOverGameObject())
            {
                //todo решение весьма сомнительное, не хотелось бы вызывать GetComponent при каждом клике
                _interactableItemTarget = hit.transform.gameObject.GetComponent<IInteractableItem>();
                MoveToPoint(hit.point);
            }
        }

        public void Initialize()
        {
            _mainCamera = Camera.main;
        }

        private void SetMovementState()
        {
            _characterCurrentState = _isMoving ? ECharacterState.Walk : ECharacterState.Idle;
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

        private void CheckInteract()
        {
            _characterCommand = _interactableItemTarget != null &&
                                Vector3.Distance(_characterView.transform.position, _interactableItemTarget.Transform.position) < 3f // todo вынести в конфиг
                ? ECharacterCommand.Interact
                : ECharacterCommand.None;
        }
        //todo не забыть про убрать эту заглушку
        private void Extract()
        {
            if (_characterCommand == ECharacterCommand.Interact)
                _cityDatabase.Model.Wood += 1f;

        }
    }
}