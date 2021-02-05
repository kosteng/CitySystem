using Engine.Mediators;
using Units.Views;
using UnityEngine;
using Zenject;

namespace Units.Controllers
{
    public class PlayerMovementController : IUpdatable, IInitializable
    {
        private readonly UnitView _unitView;
        private Camera _mainCamera;

        public PlayerMovementController(UnitView unitView)
        {
            //todo нужна фабрика
            if (_unitView == null)
                _unitView = MonoBehaviour.Instantiate(unitView);
        }
        
        public void Update(float deltaTime)
        {
            _unitView.Refresh(_mainCamera);
        }

        public void Initialize()
        {
            _mainCamera = Camera.main;
        }
    }
}