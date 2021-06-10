using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;

public interface ICharacterItemExtractor
{
    void Extract(IInteractableItem item, CharacterModel characterModel);
}
