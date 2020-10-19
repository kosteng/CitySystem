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
      Container.BindInstance(_canvas);
      Instantiate(_canvas);
      Container.BindInstance(_dayCounterDataBase);
      Container.BindInstance(_house);
      Container.BindInstance(_canvas._CityView);
      Container.Bind<DayCounterView>().FromInstance(_canvas._DayCounterView);
      

      Container.BindInstance(_canvas._BottomPanelView);
      var can = Instantiate(_canvas._BottomPanelView, _canvas.transform);
      can.transform.parent = _canvas.transform;

   }
}