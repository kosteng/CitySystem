﻿using Characters;
using Characters.Controllers;
using Engine.Mediators;
using InputControls;
using InputControls.InpitClicker;
using Items.ResourceItems;
using UnityEngine;


namespace Units.Controllers
{
    public class CharacterMovementController : IUpdatable
    {
        private readonly IInputClicker _inputClicker;
        private readonly IPlayerInputControls _playerInputControls;
        private readonly ICharacterAnimationSwitcher _characterAnimationSwitcher;
        private readonly ICharacterItemExtractor _characterItemExtractor;
        private readonly CharacterModel _characterModel;
        private Vector3 _pointDestination;
        
        public Transform UnitViewTransform => _characterModel.View.transform;
        public CharacterModel CharacterModel => _characterModel;
        public CharacterMovementController(
            CharactersDatabase charactersDatabase,
            IInputClicker inputClicker,
            IPlayerInputControls playerInputControls,
            ICharacterAnimationSwitcher characterAnimationSwitcher,
            ICharacterItemExtractor characterItemExtractor,
            ResourceItemsDatabase resourceItemsDatabase)
        {
            _inputClicker = inputClicker;
            _playerInputControls = playerInputControls;
            _characterAnimationSwitcher = characterAnimationSwitcher;
            _characterItemExtractor = characterItemExtractor;

            _characterModel = new CharacterModel(resourceItemsDatabase);
            //todo нужна фабрика
            if (_characterModel.View == null)
                _characterModel.View = Object.Instantiate(charactersDatabase.CharacterModels[0].View);
        }

        public void Update(float deltaTime)
        {
            _playerInputControls.PressCheatAddResources(_characterModel.ResourcesStorage);
            _characterModel.IsMoving =
                _characterModel.View.NavMeshAgent.remainingDistance > _characterModel.View.NavMeshAgent.stoppingDistance;
            CheckTargetForMove();

            if (_characterModel.IsMoving)
                CheckStopState();

            _characterAnimationSwitcher.UpdateAnimation(_characterModel);
            SetMovementState();
            CheckInteract();
            _characterItemExtractor.Extract(_characterModel);
        }

        private void CheckTargetForMove()
        {
            if (_inputClicker.Click(ref _characterModel.InteractableItemTarget, ref _pointDestination))
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
            _characterModel.CharacterCurrentState =
                _characterModel.InteractableItemTarget != null && _characterModel.View.NavMeshAgent.remainingDistance < 1.3f // todo вынести в конфиг
                    ? ECharacterState.Interact
                    : _characterModel.CharacterCurrentState;
        }
    }
}