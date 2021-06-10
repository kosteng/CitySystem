using UnityEngine;

public interface IInteractableItem
{
    Transform Transform { get; }
    float RespawnTime { get; }
    float LifeTime { get; }
}
