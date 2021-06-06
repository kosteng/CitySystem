using Characters;
using Engine.Mediators;
using UnityEngine;

namespace Units.Controllers
{
    public class CharacterMovementController : IUpdatable
    {
        private readonly CityDatabase _cityDatabase;
        private readonly IInputClicker _inputClicker;
        private readonly ICharacterAnimationSwitcher _characterAnimationSwitcher;
        private CharacterModel _characterModel; 
        private Vector3 _pointDestination;
        private IInteractableItem _interactableItemTarget;

        public Transform UnitViewTransform => _characterModel.View.transform;

        public CharacterMovementController(
            CharactersDatabase charactersDatabase,
            CityDatabase cityDatabase,
            IInputClicker inputClicker,
            ICharacterAnimationSwitcher characterAnimationSwitcher
            )
        {
           // _characterModel = charactersDatabase.CharacterModels[0];
            _cityDatabase = cityDatabase;
            _inputClicker = inputClicker;
            _characterAnimationSwitcher = characterAnimationSwitcher;
            _characterModel = new CharacterModel();

            //todo нужна фабрика
            if (_characterModel.View == null)
                _characterModel.View = Object.Instantiate(charactersDatabase.CharacterModels[0].View);
        }

        public void Update(float deltaTime)
        {
            _characterModel.IsMoving = _characterModel.View.NavMeshAgent.remainingDistance > _characterModel.View.NavMeshAgent.stoppingDistance;
            CheckInteract();
            CheckTargetForMove();
            Debug.Log(_characterModel.CharacterCommand.ToString());
 
            Debug.Log(_characterModel.IsMoving);
            if (_characterModel.IsMoving)
                CheckStopState();
            _characterAnimationSwitcher.UpdateAnimation(_characterModel);

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
            _characterModel.CharacterCurrentState = _characterModel.IsMoving ? ECharacterState.Move : ECharacterState.Idle;
        }

        private void MoveToPoint(Vector3 point)
        {
            _characterModel.View.transform.LookAt(point);
            _pointDestination = point;
            _characterModel.View.NavMeshAgent.SetDestination(_pointDestination);
        }

        private void CheckStopState()
        {
            _characterModel.View.NavMeshAgent.isStopped = !_characterModel.IsMoving;
        }

        private void CheckInteract()
        {
            _characterModel.CharacterCommand = _interactableItemTarget != null && _characterModel.View.NavMeshAgent.remainingDistance < 1f
                //  Vector3.Distance(_characterView.transform.position, _interactableItemTarget.Transform.position) < 3f // todo вынести в конфиг
                ? ECharacterCommand.Interact
                : ECharacterCommand.None;
        }

        //todo не забыть про убрать эту заглушку
        private void Extract()
        {
            if (_interactableItemTarget == null)
                return;

            if (_characterModel.CharacterCommand == ECharacterCommand.Interact)
            {
                _characterModel.View.transform.LookAt(_interactableItemTarget.Transform);
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