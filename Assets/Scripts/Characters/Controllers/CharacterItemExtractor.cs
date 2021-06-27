using City;
using Items.InteractItems;
using System.Linq;
using UnityEngine;

namespace Characters.Controllers
{
    public class CharacterItemExtractor : ICharacterItemExtractor
    {

        private readonly InteractItemsDatabase _interactItemsDatabase;

        public CharacterItemExtractor(InteractItemsDatabase interactItemsDatabase)
        {
            _interactItemsDatabase = interactItemsDatabase;
        }

        public void Extract(CharacterModel characterModel)
        {
            if (characterModel.InteractableItemTarget == null)
                return;

            if (characterModel.CharacterCurrentState != ECharacterState.Interact)
                return;

            characterModel.InteractableItemTarget.ExtractTime -= Time.deltaTime;
            characterModel.View.transform.LookAt(characterModel.InteractableItemTarget.Transform);
            CheckLifeStatus(characterModel);
        }

        private void CheckLifeStatus(CharacterModel characterModel)
        {
            var interactItem = characterModel.InteractableItemTarget;
            
            if (interactItem.ExtractTime > 0)
                return;
            //todo думаю добавить в словарик
            var resources =
                _interactItemsDatabase.InteractItemsData.FirstOrDefault(i => i.Type == interactItem.ItemType);
            
            characterModel.CharacterCurrentState = ECharacterState.Idle;
            
            foreach (var resourceItem in resources.ResourceItemsPriceDataWithRandom)
            {
                var amountResource = Random.Range(resourceItem.MinAmount, resourceItem.MaxAmount);

                Debug.Log($"{resourceItem.ItemType} {amountResource}");
                characterModel.ResourcesStorage.AddResource(resourceItem.ItemType, amountResource);
            }

            interactItem.Transform.gameObject.SetActive(false);
            interactItem.IsExtracted = true;
            characterModel.InteractableItemTarget = null;
        }
    }
}