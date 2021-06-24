using Items.InteractItems.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace InputControls.InpitClicker
{
    public class InputClicker : IInputClicker, IInitializable
    {
        private Camera _mainCamera;
        private const int LEFT_MOUSE_BUTTON = 1;
        public bool Click(ref IInteractableItem item, ref Vector3 hitPoint)
        {
            if (!Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
                return false;

            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, 100f) || EventSystem.current.IsPointerOverGameObject())
                return false;
        
            //todo решение весьма сомнительное, не хотелось бы вызывать GetComponent при каждом клике
            item = hit.transform.gameObject.GetComponent<IInteractableItem>();
            hitPoint = hit.point;

            return true;
        }
    
        public void Initialize()
        {
            _mainCamera = Camera.main;
        }
    }
}
