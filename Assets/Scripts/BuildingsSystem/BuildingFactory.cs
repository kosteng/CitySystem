using BuildingsSystem.Databases;
using BuildingsSystem.Enums;
using BuildingsSystem.Views;
using City;
using UnityEngine;

namespace BuildingsSystem
{
    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding Create(ABuildingView montageBuilding, BuildingDatabase currentBuilding,
            CityModel cityModel)
        {
            switch (currentBuilding.BuildingType)
            {
                case EBuildingType.House:
                    return new HouseBuildingModel(montageBuilding, currentBuilding.IncomeResources, cityModel,
                        EBuildingType.House);

                case EBuildingType.SawMill:
                    return new SawBuildingModel(montageBuilding, currentBuilding.IncomeResources, cityModel,
                        EBuildingType.SawMill);

                case EBuildingType.Mine:
                    return new MineBuildingModel(montageBuilding, currentBuilding.IncomeResources, cityModel,
                        EBuildingType.Mine);

                case EBuildingType.Storage:
                    return new StorageBuildingModel(montageBuilding, currentBuilding.IncomeResources, cityModel,
                        EBuildingType.Storage);

                default: return null;
                //new NullReferenceException($"Unkwown type {_currentBuilding.BuildingType}");Debug.LogError($"Unkwown type {_currentBuilding.BuildingType}");
            }
        }

        public ABuildingView Create(ABuildingView montageBuilding)
        {
            return MonoBehaviour.Instantiate(montageBuilding);
        }
    }
}