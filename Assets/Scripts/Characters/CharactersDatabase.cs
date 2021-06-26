using Characters;
using System.Collections.Generic;
using Units;
using UnityEngine;

[CreateAssetMenu(menuName = "DatabasesSO/CharactersDatabase")]
public class CharactersDatabase : ScriptableObject
{
    [SerializeField] private List<CharacterModel> _characterModels;
    public List<CharacterModel> CharacterModels => _characterModels;
}
