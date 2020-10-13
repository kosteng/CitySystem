using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class BuildinsStorage
    {
        public readonly List<IBuilding> Buildings;
        public BuildinsStorage(HouseBuildingView House)
        {
            Buildings = new List<IBuilding>();
            Buildings.Add(House);
        }
    }
}
