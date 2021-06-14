using UnityEngine;

namespace Items.Interfaces
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
