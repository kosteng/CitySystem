using BuildingsSystem.Databases;
using BuildingsSystem.Enums;
using BuildingsSystem.Interfaces;
using BuildingsSystem.Views;
using City;
using Items.ResourceItems;
using UnityEngine;

namespace BuildingsSystem
{
    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding Create(ABuildingView view, BuildingDatabase currentBuilding,
            IResourcesStorage resourcesStorage)
        {
            switch (currentBuilding.BuildingType)
            {
                case EBuildingType.House:
                    return new HouseBuildingModel(view, currentBuilding, resourcesStorage);

                case EBuildingType.SawMill:
                    return new SawBuildingModel(view, currentBuilding,  resourcesStorage);

                case EBuildingType.Mine:
                    return new MineBuildingModel(view, currentBuilding,  resourcesStorage);


                case EBuildingType.Storage:
                    return new StorageBuildingModel(view, currentBuilding,  resourcesStorage);
  

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