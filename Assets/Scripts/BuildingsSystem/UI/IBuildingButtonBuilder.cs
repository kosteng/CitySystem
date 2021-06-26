using BuildingsSystem.UI.BuildingInfoBuyPanel;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingsSystem.UI
{
    public interface IBuildingButtonBuilder
    {
        List<BuildingButtonView> Create(Transform parent);
    }
}