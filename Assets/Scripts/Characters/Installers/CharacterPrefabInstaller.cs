
using Units.Views;
using UnityEngine;
using Zenject;

namespace BuildingsSystem.Installers
{
    [CreateAssetMenu(menuName = "DatabasesSO/CharactersPrefabInstaller")]
    public class CharacterPrefabInstaller : ScriptableObjectInstaller
    {
        //todo надо будет перевести всех юнитов либо в массив либо как то разделить минимум на три сущности 1 игрок 2 жители 3 враги и нпс
        [SerializeField] private CharacterView _player;
        [SerializeField] private CharactersDatabase _charactersDatabase;
        public override void InstallBindings()
        {
            Container.BindInstance(_player);
            Container.BindInstance(_charactersDatabase);
        }
    }
}