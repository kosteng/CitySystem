using Building;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "DatabasesSO/DayCounterPrefabInstaller")]
public class DayCounterPrefabInstaller : ScriptableObjectInstaller
{
   [SerializeField] private DayCounterView _dayCounterView;
   [SerializeField] private DayCountDatabase _dayCounterDataBase;
   [SerializeField] private HouseBuildingView _house;
   [SerializeField] private ConvasContiener _canvas;

   public override void InstallBindings()
   {
      Container.BindInstance(_dayCounterDataBase);
      Container.BindInstance(_house);
      Container.BindInstance(_canvas._CityView);

   }
}