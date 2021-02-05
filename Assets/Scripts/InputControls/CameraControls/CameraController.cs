using Engine.Mediators;
using UnityEngine;
using Zenject;

namespace InputControls.CameraControls
{
    public class CameraController : IUpdatable, IInitializable, ILateUpdatable 
    {
        private CameraView _cameraView;
        // public Transform Target
        // {
        //     set { _cameraView.Target = value; }
        // }
        public CameraController(CameraView cameraView)
        {
            _cameraView = cameraView;
        }

        public void Update(float deltaTime)
        {
            _cameraView.Move();
        }

        public void Initialize()
        {
            _cameraView = MonoBehaviour.Instantiate(_cameraView);
        }

        public void LateUpdate(float deltaTime)
        {
           // _cameraView.LateRefresh();
        }
    }
}
