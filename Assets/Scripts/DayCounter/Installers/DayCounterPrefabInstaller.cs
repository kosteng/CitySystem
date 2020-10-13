using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "DatabasesSO/DayCounterPrefabInstaller")]
public class DayCounterPrefabInstaller : ScriptableObjectInstaller
{
   [SerializeField] private DayCounterView _dayCounterView;
   [SerializeField] private DayCountDatabase _dayCounterDataBase;

   public override void InstallBindings()
   {
      Container.Bind<DayCounterView>().FromComponentInNewPrefab(_dayCounterView).AsSingle();
   //   Container.BindInstance(_dayCounterView);
      Container.BindInstance(_dayCounterDataBase);
   }
}