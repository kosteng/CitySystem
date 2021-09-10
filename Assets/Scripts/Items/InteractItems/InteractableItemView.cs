using Items.InteractItems.Interfaces;
using UnityEngine;

namespace Items.InteractItems
{
    public class InteractableItemView : MonoBehaviour, IInteractableItem
    {
        [SerializeField] private EInteractItemType _itemType;
        [SerializeField] private float _respawnTime = 2000f;
        [SerializeField] private float _extractTime = 5f;
        [SerializeField] private float _radiusToInteract = 2f;
        public EInteractItemType ItemType => _itemType;
        public float RadiusToInteract => _radiusToInteract;
        public bool IsExtracted { get; set; }
        public Transform Transform => transform;
        public float RespawnTime { get; set; }
        public float ExtractTime { get; set; }
    
        private void SetInitialData()
        {
            RespawnTime = _respawnTime;
            ExtractTime = _extractTime;
        }

        private void Awake()
        {
            SetInitialData();
        }

        public void Reset()
        {
            IsExtracted = false;
            SetInitialData();
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
}