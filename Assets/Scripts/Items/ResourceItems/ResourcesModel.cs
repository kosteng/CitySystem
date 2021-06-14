using Items.ResourceItems;
using System;

namespace City
{
    //todo переписать избрать от SO, не хранить ресурсы в SO
    [Serializable]
    public class ResourcesModel
    {
        public ResourceItemData Gold;
        public ResourceItemData Food;
        public ResourceItemData Wood;
        public ResourceItemData Stone;
        public ResourceItemData Iron;


        public void ClearData()
        {

            Gold.Amount = 0;
            Food.Amount = 0;
            Wood.Amount = 0;
            Stone.Amount = 0;
            Iron.Amount = 0;
        }
    }
}