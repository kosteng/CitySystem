using System;
using Characters;
using Items.Interfaces;
using Units.Views;

namespace Units
{
    [Serializable]
    public class CharacterModel
    {
        public CharacterView View;
        public bool IsMoving;
        public ECharacterState CharacterCurrentState = ECharacterState.Idle;
        public ECharacterCommand CharacterCommand = ECharacterCommand.None;
        public IInteractableItem InteractableItemTarget;
    }
}