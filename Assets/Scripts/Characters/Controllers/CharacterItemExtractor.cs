using Characters;
using Units;
using UnityEngine;

public class CharacterItemExtractor : ICharacterItemExtractor
{
    private readonly CityDatabase _cityDatabase;

    public CharacterItemExtractor(CityDatabase cityDatabase)
    {
        _cityDatabase = cityDatabase;
    }
    public void Extract(CharacterModel characterModel)
    {
        if (characterModel.InteractableItemTarget == null)
            return;

        if (characterModel.CharacterCurrentState != ECharacterState.Interact) 
            return;

        characterModel.InteractableItemTarget.LifeTime -= Time.deltaTime;
        characterModel.View.transform.LookAt(characterModel.InteractableItemTarget.Transform);
        CheckLifeStatus(characterModel);
    }

    private void CheckLifeStatus(CharacterModel characterModel)
    {

        if (characterModel.InteractableItemTarget.LifeTime > 0)//bbb || !interactableItem.Transform.gameObject.activeSelf)
            return;

        characterModel.CharacterCurrentState = ECharacterState.Idle;
        _cityDatabase.Model.Wood += 1f;
        Debug.Log(_cityDatabase.Model.Wood);
        characterModel.InteractableItemTarget.Transform.gameObject.SetActive(false);
        characterModel.InteractableItemTarget.IsExtracted = true;
        characterModel.InteractableItemTarget = null;
    }
}
