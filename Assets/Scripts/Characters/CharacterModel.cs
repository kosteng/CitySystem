using City;
using Items.InteractItems.Interfaces;
using Items.ResourceItems;
using System;
using Units.Views;

namespace Characters
{
    [Serializable]
    public class CharacterModel
    {
        public CharacterView View;
        public ResourcesStorage ResourcesStorage;
        public bool IsMoving;
        public ECharacterState CharacterCurrentState = ECharacterState.Idle;
        public ECharacterCommand CharacterCommand = ECharacterCommand.None;
        public IInteractableItem InteractableItemTarget;
    }
}