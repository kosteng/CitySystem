using System.Collections;
using System.Collections.Generic;

public class BuidingsStorageHandler
{
    private AllBuildingsDatabase _allBuildingsDatabase;
    public List<HouseBuildingDatabase> HouseBuildings;
    public List<SawMillBuildingDatabase> SawMillBuildings;
    public List<MineBuildingDatabase> MineBuildings;

    public BuidingsStorageHandler (AllBuildingsDatabase allBuildingsDatabase)
    {
        _allBuildingsDatabase = allBuildingsDatabase;
    }

    public void Awake()
    {
        HouseBuildings = new List<HouseBuildingDatabase>();
    }
}
