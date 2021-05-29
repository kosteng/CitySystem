using Engine.Mediators;
using UnityEngine;
using Zenject;

namespace InputControls.CameraControls
{
    public class CameraController : IUpdatable, IInitializable
    {
        private CameraView _cameraView;
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
            _cameraView = MonoBehaviour.Instantiate(_cameraView, new Vector3(0f,10f,-17f), Quaternion.identity);
        }
    }
}
