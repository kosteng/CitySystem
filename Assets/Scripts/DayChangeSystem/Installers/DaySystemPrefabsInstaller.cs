
using DayChangeSystem.Databases;
using DayChangeSystem.Views;
using UnityEngine;
using Zenject;

namespace DayChangeSystem.Installers
{
   [CreateAssetMenu(menuName = "DatabasesSO/DaySystemPrefabsInstaller")]
   public class DaySystemPrefabsInstaller : ScriptableObjectInstaller
   {
      [SerializeField] private DaySettingsDatabase _dayCounterDataBase;
      [SerializeField] private SunView _sun;
      [SerializeField] private GameObject _moon;

      public override void InstallBindings()
      {
         Container.BindInstance(_dayCounterDataBase);
         Container.BindInstance(_sun);
         Container.BindInstance(_moon);
      }
   }
}