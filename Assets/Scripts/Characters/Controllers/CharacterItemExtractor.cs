using City;
using Items.InteractItems;
using Items.ResourceItems;
using System.Linq;
using Units;
using UnityEngine;

namespace Characters.Controllers
{
    public class CharacterItemExtractor : ICharacterItemExtractor
    {
        private readonly CityController _cityController;
        private readonly InteractItemsDatabase _interactItemsDatabase;

        public CharacterItemExtractor(CityController cityController, InteractItemsDatabase interactItemsDatabase)
        {
            _cityController = cityController;
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
            var resources =
                _interactItemsDatabase.InteractItemsData.FirstOrDefault(i => i.Type == interactItem.ItemType);
            
            characterModel.CharacterCurrentState = ECharacterState.Idle;
            
            foreach (var resourceItem in resources.ResourceItemsPriceDataWithRandom)
            {
                var amountResource = Random.Range(resourceItem.MinAmount, resourceItem.MaxAmount);
                
                Debug.Log( resourceItem.ItemType + " " + amountResource);
                _cityController.CityModel.AddResource(resourceItem.ItemType, amountResource);
            }

            interactItem.Transform.gameObject.SetActive(false);
            interactItem.IsExtracted = true;
            characterModel.InteractableItemTarget = null;
        }
    }
}