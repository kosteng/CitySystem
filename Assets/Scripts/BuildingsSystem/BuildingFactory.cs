
public interface IBuildingFactory
{
    IBuilding Create(ABuildingView montageBuilding, BuildingDatabase currentBuilding, CityDatabase cityDatabase);
}

// TO DO переписать этого монстра!!! сделать отдельный класс с префабами и координатами построек
public class BuildingFactory : IBuildingFactory
{
    public IBuilding Create(ABuildingView montageBuilding, BuildingDatabase currentBuilding, CityDatabase cityDatabase)
    {
        switch (currentBuilding.BuildingType)
        {
            case EBuildingType.House:
            return new HouseBuildingModel(montageBuilding, currentBuilding.IncomeResources, cityDatabase);

            case EBuildingType.SawMill:
             return new SawBuildingModel(montageBuilding, currentBuilding.IncomeResources, cityDatabase);

            case EBuildingType.Mine:
            return new MineBuildingModel(montageBuilding, currentBuilding.IncomeResources, cityDatabase);

            default: return null;
            //new NullReferenceException($"Unkwown type {_currentBuilding.BuildingType}");Debug.LogError($"Unkwown type {_currentBuilding.BuildingType}");
 
        }
    }

}