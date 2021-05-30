using UnityEngine;


public class CameraView : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private float _rotation;
    private float _rotationZoom;
    private const float ROTATION_SPEED = 0.5f;
    private const float SPEED_SCROLL = 10f;
    private const float ZOOM_SCROLL = 100f;
    private const float ZOOM_ROTATION = 0.5f;

    //TODO по возможности переписать это дерьмо, также добавить ограничения на зум
    public void Move()
    {
        Zoom();
        Position();
        Rotation();
    }

    private void Position()
    {
        if (Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * (SPEED_SCROLL * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * (SPEED_SCROLL * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.forward * (SPEED_SCROLL * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.S))
            transform.position += Vector3.back * (SPEED_SCROLL * Time.deltaTime);
    }

    private void Rotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _rotation -= ROTATION_SPEED;
            transform.localRotation = Quaternion.Euler(0f, _rotation, 0f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            _rotation += ROTATION_SPEED;
            transform.rotation = Quaternion.Euler(0f, _rotation, 0f);
        }
    }

    private void Zoom()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        if (mouseWheel > 0)
        {
            _rotationZoom -= ZOOM_ROTATION;
            transform.Translate(0, -ZOOM_SCROLL * Time.deltaTime, 0);
            transform.localRotation = Quaternion.Euler(_rotationZoom,0, 0);
        }

        if (mouseWheel < 0)
        {
            _rotationZoom += ZOOM_ROTATION;
            transform.Translate(0, ZOOM_SCROLL * Time.deltaTime, ZOOM_ROTATION);
            transform.localRotation = Quaternion.Euler(_rotationZoom, 0, 0);
        }
    }
}


// //todo разобрать это
// [SerializeField] private Transform _target;
// [SerializeField] private Vector3 _offset;
// [SerializeField] private float _zoomSpeed = 4f;
// [SerializeField] private float _minZoom = 5f;
// [SerializeField] private float _maxZoom = 15f;
// [SerializeField] private float _pitch = 2f;
//
// private Transform _transform;
// private float _currentZoom = 10f;
// private float _currentRot = 0f;
// private float _prevMouseX;
//
// public Transform Target
// {
//     set { _target = value; }
// }
//
// void Start()
// {
//     _transform = transform;
// }
//     
//
// public void Refresh()
// {
//     if (_target != null)
//     {
//         _currentZoom -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
//         _currentZoom = Mathf.Clamp(_currentZoom, _minZoom, _maxZoom);
//
//         if (Input.GetMouseButton(2))
//         {
//             _currentRot += Input.mousePosition.x - _prevMouseX;
//         }
//     }
//
//     _prevMouseX = Input.mousePosition.x;
// }
//
// public void LateRefresh()
// {
//     if (_target != null)
//     {
//         _transform.position = _target.position - _offset * _currentZoom;
//         _transform.LookAt(_target.position + Vector3.up * _pitch);
//         _transform.RotateAround(_target.position, Vector3.up, _currentRot);
//     }
// }