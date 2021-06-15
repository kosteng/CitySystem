using System;

namespace City
{
    //todo переписать избрать от SO, не хранить ресурсы в SO
    [Serializable]
    public class ResourcesModel
    {
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