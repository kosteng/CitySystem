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

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SwitchActiveState()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}