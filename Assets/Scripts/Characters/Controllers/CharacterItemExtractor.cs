using City;
using Units;
using UnityEngine;

namespace Characters.Controllers
{
    public class CharacterItemExtractor : ICharacterItemExtractor
    {
        private readonly CityController _cityController;


        public CharacterItemExtractor(CityController cityController)
        {
            _cityController = cityController;
 
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
            if (characterModel.InteractableItemTarget.ExtractTime > 0)
                return;

            characterModel.CharacterCurrentState = ECharacterState.Idle;
            //todo количество выпадаемого ресурса требуется запихнуть в модель интерактивного итема
            _cityController.CityResourcesModel.Wood += Random.Range(3, 7);

            characterModel.InteractableItemTarget.Transform.gameObject.SetActive(false);
            characterModel.InteractableItemTarget.IsExtracted = true;
            characterModel.InteractableItemTarget = null;
        }
    }
}