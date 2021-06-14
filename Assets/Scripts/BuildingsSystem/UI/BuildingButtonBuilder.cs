using BuildingsSystem.Databases;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingsSystem.UI
{
   public class BuildingButtonBuilder 
   {
      private readonly AllBuildingsDatabase _allBuildingsDatabase;
      private readonly BuildingButtonView _buttonView;

      public BuildingButtonBuilder(AllBuildingsDatabase allBuildingsDatabase, BuildingButtonView buttonView)
      {
         _allBuildingsDatabase = allBuildingsDatabase;
         _buttonView = buttonView;
         //todo подумать куда лучше вприхнуть, возможно следует создать отдельный класс для подобных проверок всех подсистем
         foreach (var buildingDatabase in _allBuildingsDatabase.BuildingsDatabase)
         {
            buildingDatabase.VerifycationDictionary();
         }
      }

      public List<BuildingButtonView> Create(Transform parent)
      {
         List<BuildingButtonView> list = new List<BuildingButtonView>();
         foreach (var button in _allBuildingsDatabase.BuildingsDatabase)
         {
            var buildingButton = MonoBehaviour.Instantiate(_buttonView);
            buildingButton.Attach(parent);
            buildingButton.SetName(button.BuildingType.ToString());
            buildingButton.SetBuildingType(button.BuildingType);
            list.Add(buildingButton);
         }
         return list;
      }
   }
}
