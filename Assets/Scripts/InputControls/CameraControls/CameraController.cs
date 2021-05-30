using Engine.Mediators;
using UnityEngine;
using Zenject;

namespace InputControls.CameraControls
{
    public class CameraController : IUpdatable, IInitializable
    {
        private CameraView _cameraView;

        private float _rotation;
        private float _rotationZoom;
        private const float SIGN = 1f;
        
        //todo вынести значения в конфиг
        private const float ROTATION_SPEED = 0.5f;
        private const float SCROLL_SPEED = 10f;
        private const float ZOOM_SPEED = 100f;
        private const float ZOOM_ROTATION = 1f;//0.5f;
        private const float MIN_ZOOM_RANGE = 2f;
        private const float MAX_ZOOM_RANGE = 50f;

        public CameraController(CameraView cameraView)
        {
            _cameraView = cameraView;
        }

        public void Update(float deltaTime)
        {
            Zoom();
            Position();
            Rotation();
        }

        public void Initialize()
        {
            //todo фабрика плачет
            _cameraView = Object.Instantiate(_cameraView, new Vector3(0f, 10f, -17f), Quaternion.identity);
        }

        private void Position()
        {
            if (Input.GetKey(KeyCode.D))
                _cameraView.transform.Translate(Vector3.right * ( SCROLL_SPEED * Time.deltaTime ), Space.Self);

            if (Input.GetKey(KeyCode.A))
                _cameraView.transform.Translate(Vector3.left * ( SCROLL_SPEED * Time.deltaTime ), Space.Self);

            if (Input.GetKey(KeyCode.W))
                _cameraView.transform.Translate(Vector3.forward * ( SCROLL_SPEED * Time.deltaTime ), Space.Self);

            if (Input.GetKey(KeyCode.S))
                _cameraView.transform.Translate(Vector3.back * ( SCROLL_SPEED * Time.deltaTime ), Space.Self);
        }

        private void Rotation()
        {
            if (Input.GetKey(KeyCode.Q))
                CalculateRotation(-SIGN);

            if (Input.GetKey(KeyCode.E))
                CalculateRotation(SIGN);
        }

        private void Zoom()
        {
            float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

            if (mouseWheel > 0 && _cameraView.transform.position.y > MIN_ZOOM_RANGE)
                CalculateZoom(-SIGN);

            if (mouseWheel < 0 && _cameraView.transform.position.y < MAX_ZOOM_RANGE)
                CalculateZoom(SIGN);
        }

        private void CalculateZoom(float sign)
        {
            _rotationZoom += ZOOM_ROTATION * sign;
            _cameraView.transform.Translate(0, ZOOM_SPEED * Time.deltaTime * sign, 0);
            _cameraView.transform.localRotation = Quaternion.Euler(_rotationZoom, _rotation, 0);
        }

        private void CalculateRotation(float sign)
        {
            _rotation += ROTATION_SPEED * sign;
            _cameraView.transform.localRotation = Quaternion.Euler(_rotationZoom, _rotation, 0f);
        }
    }
}