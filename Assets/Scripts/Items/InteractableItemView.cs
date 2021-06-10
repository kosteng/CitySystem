using UnityEngine;

public class InteractableItemView : MonoBehaviour, IInteractableItem
{
    public Transform Transform => transform;
    public float RespawnTime { get; } = 20f;
    public float LifeTime { get; } = 5f;
}
