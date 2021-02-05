using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    
    private float _width = Screen.width;
    private float _height = Screen.height;
    private float _rotation;
    private const float SpeedScroll = 10f;
    
        //TODO по возможности переписать это дерьмо, также добавить ограничения на зум
    public void Move()
    {
        var mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        
        if (mouseWheel > 0)
            transform.Translate(0, -100f * Time.deltaTime, 0);
        
        if (mouseWheel < 0)
            transform.Translate(0, 100f * Time.deltaTime, 0);
    
        if (Input.mousePosition.x > _width || Input.GetKeyDown(KeyCode.D))
            transform.Translate(SpeedScroll * Time.deltaTime, 0, 0);
    
        if (Input.mousePosition.x < 0 || Input.GetKeyDown(KeyCode.A))
            transform.Translate(-SpeedScroll * Time.deltaTime, 0, 0);
    
        if (Input.mousePosition.y > _height || Input.GetKeyDown(KeyCode.W))
            transform.Translate(0, 0, SpeedScroll * Time.deltaTime);
    
        if (Input.mousePosition.y < 0 || Input.GetKeyDown(KeyCode.S))
            transform.Translate(0, 0, -SpeedScroll * Time.deltaTime);
    
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _rotation += SpeedScroll;
            transform.localRotation = Quaternion.Euler(0f, _rotation, 0f);
        }
    
        if (Input.GetKeyDown(KeyCode.E))
        {
            _rotation -= SpeedScroll;
            transform.rotation = Quaternion.Euler(0f, _rotation, 0f);
        }
    
        {
            
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