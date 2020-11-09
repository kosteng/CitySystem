using UnityEngine;

namespace Engine.UI
{
    public abstract class APanel : MonoBehaviour
    {
        public void Attach(Transform parent)
        {
            var rectTransform = (RectTransform) transform;
            rectTransform.SetParent(parent);
           // rectTransform.anchoredPosition = Vector2.zero;
           // rectTransform.sizeDelta = Vector2.zero;
        }
    }
}