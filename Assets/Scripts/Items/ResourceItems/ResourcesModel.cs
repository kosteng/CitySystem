using Items.ResourceItems;
using System;

namespace City
{
    //todo переписать избрать от SO, не хранить ресурсы в SO
    [Serializable]
    public class ResourcesModel
    {
        // public ResourceItemData Gold = new ResourceItemData();
        // public ResourceItemData Food = new ResourceItemData();
        // public ResourceItemData Wood = new ResourceItemData();
        // public ResourceItemData Stone = new ResourceItemData();
        // public ResourceItemData Iron = new ResourceItemData();

        public float Gold;
        public float Food;
        public float Wood;
        public float Stone;
        public float Iron;

        public void ClearData()
        {

            Gold = 0;
            Food = 0;
            Wood = 0;
            Stone = 0;
            Iron = 0;
        }
    }
}