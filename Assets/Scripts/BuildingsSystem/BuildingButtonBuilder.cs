using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButtonBuilder 
{
   private readonly AllBuildingsDatabase _allBuildingsDatabase;

   public BuildingButtonBuilder(AllBuildingsDatabase allBuildingsDatabase)
   {
      _allBuildingsDatabase = allBuildingsDatabase;
   }

   public void Create()
   {
      foreach (var button in _allBuildingsDatabase.BuildingDatabases)
      {
         // сделаю вид что я написал этот код
      }
   }
}
