
using Units.Views;
using UnityEngine;
using Zenject;

namespace BuildingsSystem.Installers
{
    [CreateAssetMenu(menuName = "DatabasesSO/UnitsPrefabInstaller")]
    public class UnitPrefabInstaller : ScriptableObjectInstaller
    {
        //todo надо будет перевести всех юнитов либо в массив либо как то разделить минимум на три сущности 1 игрок 2 жители 3 враги и нпс
        [SerializeField] private UnitView _player; 
 
        public override void InstallBindings()
        {
            Container.BindInstance(_player);
        }
    }
}