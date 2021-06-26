using Items.ResourceItems;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryCellView : MonoBehaviour
    {
        private EResourceItemType _itemType;
        public Text Title;
        [SerializeField] private Text _amount;
        public float Amount;
        public EResourceItemType ItemType => _itemType;

        public void SetItemType(EResourceItemType type)
        {
            _itemType = type;
        }

        public void RefreshAmount()
        {
            _amount.text = Amount.ToString();
        }
    }
}