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
        public IResourcesStorage ResourcesStorage;
        public bool IsMoving;
        public ECharacterState CharacterCurrentState = ECharacterState.Idle;
        public ECharacterCommand CharacterCommand = ECharacterCommand.None;
        public IInteractableItem InteractableItemTarget;

        public CharacterModel(ResourceItemsDatabase resourceItemsDatabase)
        {
            ResourcesStorage = new ResourcesStorage(resourceItemsDatabase);
        }
    }
}