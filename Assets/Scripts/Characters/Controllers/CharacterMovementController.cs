using Characters;
using Engine.Mediators;
using Units.Views;
using UnityEngine;

public enum ECharacterCommand
{
    None,
    Interact,
    Move
}


namespace Units.Controllers
{
    public class CharacterMovementController : IUpdatable
    {
        private readonly CityDatabase _cityDatabase;
        private readonly IInputClicker _inputClicker;
        private readonly ICharacterAnimationSwitcher _characterAnimationSwitcher;
        private readonly CharacterView _characterView;
        
        private Vector3 _pointDestination;
        private IInteractableItem _interactableItemTarget;
        
        public Transform UnitViewTransform => _characterView.transform;

        public CharacterMovementController(CharacterView characterView, 
            CityDatabase cityDatabase, 
            IInputClicker inputClicker, 
            ICharacterAnimationSwitcher characterAnimationSwitcher)
        {
            _cityDatabase = cityDatabase;
            _inputClicker = inputClicker;
            _characterAnimationSwitcher = characterAnimationSwitcher;
            //todo нужна фабрика
            if (_characterView == null)
                _characterView = Object.Instantiate(characterView);
        }

        public void Update(float deltaTime)
        {
            _characterView.IsMoving = _characterView.NavMeshAgent.remainingDistance > _characterView.NavMeshAgent.stoppingDistance;
            CheckInteract();
            CheckTargetForMove();
            Debug.Log(_characterView.CharacterCommand.ToString());
            Debug.Log(_characterView.IsMoving);
          //  Debug.Log(_pointDestination);
            //  Debug.Log("_isMoving " +_isMoving);
            if (_characterView.IsMoving)
                CheckStopState();
            _characterAnimationSwitcher.UpdateAnimation(_characterView);

            SetMovementState();
            Extract();
        }

        private void CheckTargetForMove()
        {
            if (_inputClicker.Click(ref _interactableItemTarget, ref _pointDestination))
                MoveToPoint(_pointDestination);
        }

        private void SetMovementState()
        {
            _characterView.CharacterCurrentState = _characterView.IsMoving ? ECharacterState.Move : ECharacterState.Idle;
        }

        private void MoveToPoint(Vector3 point)
        {
            _characterView.transform.LookAt(point);
            _pointDestination = point;
            _characterView.NavMeshAgent.SetDestination(_pointDestination);
        }

        private void CheckStopState()
        {
            _characterView.NavMeshAgent.isStopped = !_characterView.IsMoving;
        }

        private void CheckInteract()
        {
            _characterView.CharacterCommand = _interactableItemTarget != null && _characterView.NavMeshAgent.remainingDistance < 1f
                //  Vector3.Distance(_characterView.transform.position, _interactableItemTarget.Transform.position) < 3f // todo вынести в конфиг
                ? ECharacterCommand.Interact
                : ECharacterCommand.None;
        }

        //todo не забыть про убрать эту заглушку
        private void Extract()
        {
            if (_characterView.CharacterCommand == ECharacterCommand.Interact)
            {
                _characterView.transform.LookAt(_interactableItemTarget.Transform);
                _cityDatabase.Model.Wood += 1f;
            }
        }
    }
}

//
// using Characters;
// using Engine.Mediators;
// using Units.Views;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using Zenject;
//
//
// public enum ECharacterCommand
// {
//     None,
//     Interact,
//     Move
// }
//
//
// namespace Units.Controllers
// {
//     public class CharacterMovementController : IUpdatable, IInitializable
//     {
//         private readonly CityDatabase _cityDatabase;
//         private static readonly int _moving = Animator.StringToHash("Moving");
//         private static readonly int _extract = Animator.StringToHash("Extracting");
//         private readonly CharacterView _characterView;
//         private Camera _mainCamera;
//         private ECharacterState _characterCurrentState = ECharacterState.Idle;
//         private ECharacterCommand _characterCommand = ECharacterCommand.None;
//         private const int LEFT_MOUSE_BUTTON = 1;
//         private bool _isMoving;
//         private Vector3 _pointDestination;
//         private IInteractableItem _interactableItemTarget;
//         public Transform UnitViewTransform => _characterView.transform;
//
//         public CharacterMovementController(CharacterView characterView, CityDatabase cityDatabase)
//         {
//             _cityDatabase = cityDatabase;
//             //todo нужна фабрика
//             if (_characterView == null)
//                 _characterView = Object.Instantiate(characterView);
//         }
//
//         public void Update(float deltaTime)
//         {
//             CheckTargetForMove(_mainCamera);
//             CheckInteract();
//             CheckStopState();
//             UpdateAnimation();
//             SetMovementState();
//             Extract();
//         }
//
//         private void CheckTargetForMove(Camera camera)
//         {
//             if (!Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON)) return;
//
//             var ray = camera.ScreenPointToRay(Input.mousePosition);
//
//             if (Physics.Raycast(ray, out var hit, 100f) && !EventSystem.current.IsPointerOverGameObject())
//             {
//                 //todo решение весьма сомнительное, не хотелось бы вызывать GetComponent при каждом клике
//                 _interactableItemTarget = hit.transform.gameObject.GetComponent<IInteractableItem>();
//                 MoveToPoint(hit.point);
//             }
//         }
//
//         public void Initialize()
//         {
//             _mainCamera = Camera.main;
//         }
//
//         private void SetMovementState()
//         {
//             _characterCurrentState = _isMoving ? ECharacterState.Move : ECharacterState.Idle;
//         }
//
//         private void MoveToPoint(Vector3 point)
//         {
//             _characterView.transform.LookAt(point);
//             _pointDestination = point;
//             _characterView.NavMeshAgent.SetDestination(_pointDestination);
//         }
//
//         private void CheckStopState()
//         {
//             _isMoving = _characterView.NavMeshAgent.remainingDistance > _characterView.NavMeshAgent.stoppingDistance;
//             _characterView.NavMeshAgent.isStopped = !_isMoving;
//         }
//
//         private void UpdateAnimation()
//         {
//             _characterView.Animator.SetBool(_moving, _isMoving);
//             _characterView.Animator.SetBool(_extract,_characterCommand == ECharacterCommand.Interact);
//         }
//
//         private void CheckInteract()
//         {
//             _characterCommand = _interactableItemTarget != null &&
//                                 Vector3.Distance(_characterView.transform.position, _interactableItemTarget.Transform.position) < 3f // todo вынести в конфиг
//                 ? ECharacterCommand.Interact
//                 : ECharacterCommand.None;
//         }
//         //todo не забыть про убрать эту заглушку
//         private void Extract()
//         {
//             if (_characterCommand == ECharacterCommand.Interact)
//             {
//                 _characterView.transform.LookAt(_interactableItemTarget.Transform);
//                 _cityDatabase.Model.Wood += 1f;
//             }
//         }
//     }
// }