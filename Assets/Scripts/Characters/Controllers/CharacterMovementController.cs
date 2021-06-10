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
        private readonly ICharacterItemExtractor _characterItemExtractor;
        private readonly CharacterModel _characterModel; 
        private Vector3 _pointDestination;
        private IInteractableItem _interactableItemTarget;

        public Transform UnitViewTransform => _characterModel.View.transform;

        public CharacterMovementController(
            CharactersDatabase charactersDatabase,
            CityDatabase cityDatabase,
            IInputClicker inputClicker,
            ICharacterAnimationSwitcher characterAnimationSwitcher,
            ICharacterItemExtractor characterItemExtractor
            )
        {
            _cityDatabase = cityDatabase;
            _inputClicker = inputClicker;
            _characterAnimationSwitcher = characterAnimationSwitcher;
            _characterItemExtractor = characterItemExtractor;
            _characterModel = new CharacterModel();

            //todo нужна фабрика
            if (_characterModel.View == null)
                _characterModel.View = Object.Instantiate(charactersDatabase.CharacterModels[0].View);
        }

        public void Update(float deltaTime)
        {
            _characterModel.IsMoving = _characterModel.View.NavMeshAgent.remainingDistance > _characterModel.View.NavMeshAgent.stoppingDistance;
            CheckTargetForMove();

            if (_characterModel.IsMoving)
                CheckStopState();
            
            _characterAnimationSwitcher.UpdateAnimation(_characterModel);
            SetMovementState();
            CheckInteract();
            _characterItemExtractor.Extract(_interactableItemTarget, _characterModel);
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
            _characterModel.CharacterCurrentState = _interactableItemTarget != null && _characterModel.View.NavMeshAgent.remainingDistance < 1f // todo вынести в конфиг
                ? ECharacterState.Interact
                : _characterModel.CharacterCurrentState;
        }
    }
}
