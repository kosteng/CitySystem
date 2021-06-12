using UnityEngine;

public interface IInteractableItem
{
    EInteractItemType ItemType { get; }
    bool IsExtracted { get; set; }
    Transform Transform { get; }
    float RespawnTime { get; set; }
    float LifeTime { get; set; }
    void Reset();
    void CheckRespawnStatus();
}
