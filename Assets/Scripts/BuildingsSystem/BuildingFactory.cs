using UnityEngine;

namespace BuildingsSystem
{
    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding Create(ABuildingView montageBuilding, BuildingDatabase currentBuilding, CityDatabase cityDatabase)
        {
            switch (currentBuilding.BuildingType)
            {
                case EBuildingType.House:
                    return new HouseBuildingModel(montageBuilding, currentBuilding.IncomeResources, cityDatabase, EBuildingType.House);

                case EBuildingType.SawMill:
                    return new SawBuildingModel(montageBuilding, currentBuilding.IncomeResources, cityDatabase, EBuildingType.SawMill);

                case EBuildingType.Mine:
                    return new MineBuildingModel(montageBuilding, currentBuilding.IncomeResources, cityDatabase, EBuildingType.Mine);

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