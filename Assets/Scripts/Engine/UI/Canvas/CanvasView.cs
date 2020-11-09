using UnityEngine;

namespace Engine.UI
{
    public class CanvasView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;

        public void Attach(IAttachableUi attachable)
        {
            attachable.Attach(_transform);
        }
    }
}
