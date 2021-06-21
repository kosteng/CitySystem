using UnityEngine;

namespace Items.InteractItems.Interfaces
{
    public interface IInteractableItem
    {
        EInteractItemType ItemType { get; }
        bool IsExtracted { get; set; }
        Transform Transform { get; }
        float RespawnTime { get; set; }
        float ExtractTime { get; set; }
        void Reset();
        void CheckRespawnStatus();
    }
}
