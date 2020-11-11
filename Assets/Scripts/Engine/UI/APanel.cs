using UnityEngine;

namespace Engine.UI
{
    public abstract class APanel : MonoBehaviour
    {
        public void Attach(Transform parent)
        {
            var rectTransform = (RectTransform) transform;
            rectTransform.SetParent(parent, false);
        }
    }
}