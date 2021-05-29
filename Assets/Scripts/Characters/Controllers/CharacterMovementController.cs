using Characters;
using Engine.Mediators;
using Units.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Units.Controllers
{
    public class CharacterMovementController : IUpdatable, IInitializable
    {
        private readonly CharacterView _characterView;
        private Camera _mainCamera;
        private ECharacterState _characterState;
        public Transform UnitViewTransform => _characterView.transform;

        public CharacterMovementController(CharacterView characterView)
        {
            //todo нужна фабрика
            if (_characterView == null)
                _characterView = MonoBehaviour.Instantiate(characterView);
        }

        public void StopUnit()
        {
            _characterView.NavMeshAgent.Stop(); 
        }
        
        public void Update(float deltaTime)
        {
            PlayerMove(_mainCamera);
        }

        private void PlayerMove(Camera camera)
        {
            if (Input.GetMouseButtonDown(1))
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit, 100f) && !EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log(hit.transform.gameObject.name);
                    _characterView.MoveToPoint(hit.point);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f))
                {
 
                }
            }
        }

        public void Initialize()
        {
            _mainCamera = Camera.main;
        }
    }
}