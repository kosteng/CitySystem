using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(menuName = "DatabasesSO/CharactersDatabase")]
    public class CharactersDatabase : ScriptableObject
    {
        [SerializeField] private List<CharacterModel> _characterModels;
        public List<CharacterModel> CharacterModels => _characterModels;
    }
}
