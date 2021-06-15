using BuildingsSystem.Databases;
using BuildingsSystem.Enums;
using BuildingsSystem.Views;
using City;
using UnityEngine;

namespace BuildingsSystem
{
    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding Create(BuildingDatabase currentBuilding,
            CityModel cityModel)
        {
            switch (currentBuilding.BuildingType)
            {
                case EBuildingType.House:
                    return new HouseBuildingModel(currentBuilding, cityModel);

                case EBuildingType.SawMill:
                    return new SawBuildingModel(currentBuilding,  cityModel);

                case EBuildingType.Mine:
                    return new MineBuildingModel(currentBuilding,  cityModel);


                case EBuildingType.Storage:
                    return new StorageBuildingModel(currentBuilding,  cityModel);
  

                default: return null;
                //new NullReferenceException($"Unkwown type {_currentBuilding.BuildingType}");Debug.LogError($"Unkwown type {_currentBuilding.BuildingType}");
            }
        }

        public ABuildingView Create(ABuildingView montageBuilding)
        {
            return Object.Instantiate(montageBuilding);
        }
    }
}