using Items;
using UnityEngine;

public class  InteractableItemView : MonoBehaviour, IInteractableItem
{
    [SerializeField] private EInteractItemType _itemType;
    public EInteractItemType ItemType => _itemType;
    public bool IsExtracted { get; set; }
    public Transform Transform => transform;
    public float RespawnTime  { get;  set; } = 20f;
    public float LifeTime { get;  set; } = 5f;

    public void Reset()
    {
        IsExtracted = false;
        RespawnTime = 20f;
        LifeTime = 5f;
        transform.gameObject.SetActive(true);
    }

    public void CheckRespawnStatus()
    {
        if (!IsExtracted)
            return;

        if (RespawnTime < 0)
        {
            Reset();
        }
        else
        {
            RespawnTime -= Time.deltaTime;
        }
    }
}
