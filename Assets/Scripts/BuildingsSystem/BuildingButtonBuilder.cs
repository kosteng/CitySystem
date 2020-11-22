using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButtonBuilder 
{
   private readonly AllBuildingsDatabase _allBuildingsDatabase;
   private readonly BuildingButtonView _buttonView;

   public BuildingButtonBuilder(AllBuildingsDatabase allBuildingsDatabase, BuildingButtonView buttonView)
   {
      _allBuildingsDatabase = allBuildingsDatabase;
      _buttonView = buttonView;
   }

   public void Create(Transform parent)
   {
      foreach (var button in _allBuildingsDatabase.BuildingsDatabase)
      {
         var buildingButton = MonoBehaviour.Instantiate(_buttonView);
         buildingButton.Attach(parent);
         buildingButton.SetName(button.BuildingType.ToString());
      }
   }
}
