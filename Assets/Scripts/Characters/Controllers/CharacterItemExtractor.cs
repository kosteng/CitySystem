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
    public void Extract(IInteractableItem item, CharacterModel characterModel)
    {
        if (item == null)
            return;

        if (characterModel.CharacterCurrentState == ECharacterState.Interact)
        {
            Debug.Log(ECharacterState.Interact.ToString());
            characterModel.View.transform.LookAt(item.Transform);
            _cityDatabase.Model.Wood += 1f;
        }
    }
}
