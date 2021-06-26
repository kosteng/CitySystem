using BuildingsSystem.Databases;
using BuildingsSystem.UI.BuildingInfoBuyPanel;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingsSystem.UI
{
   public class BuildingButtonBuilder : IBuildingButtonBuilder
   {
      private readonly BuildingsModelDatabase _buildingsModelDatabase;
      private readonly BuildingButtonView _buttonView;

      public BuildingButtonBuilder(BuildingsModelDatabase buildingsModelDatabase, BuildingButtonView buttonView)
      {
         _buildingsModelDatabase = buildingsModelDatabase;
         _buttonView = buttonView;
         //todo подумать куда лучше вприхнуть, возможно следует создать отдельный класс для подобных проверок всех подсистем
         foreach (var buildingDatabase in _buildingsModelDatabase.BuildingsDatabase)
         {
            buildingDatabase.VerifycationDictionary();
         }
      }

      public List<BuildingButtonView> Create(Transform parent)
      {
         List<BuildingButtonView> list = new List<BuildingButtonView>();
         foreach (var button in _buildingsModelDatabase.BuildingsDatabase)
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
