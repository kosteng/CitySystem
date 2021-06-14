using System;
using UnityEngine;

//TODO вернуть абстрактность классу
namespace BuildingsSystem.Views
{
    public class ABuildingView : MonoBehaviour
    {
        [SerializeField] private Renderer MainRenderer;
        [SerializeField] private Vector2Int Size = Vector2Int.one;

        public Action OnBuildingClick;

        public bool IsPlaceFree { get; private set; } = true;

        public void SetTransparent(bool available)
        {
            if (available)
            {
                foreach (var material in MainRenderer.materials)
                {
                    material.color = Color.green;
                }
            }
            else
            {
                foreach (var material in MainRenderer.materials)
                {
                    material.color = Color.red;
                }
            }
        }

        public void OnMouseDown()
        {
            OnBuildingClick?.Invoke();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Building"))
                IsPlaceFree = false;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Building"))
                IsPlaceFree = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Building"))
                IsPlaceFree = false;
        }

        public void SetNormal()
        {
            foreach (var material in MainRenderer.materials)
            {
                material.color = Color.white;
            }
        }
    }
}