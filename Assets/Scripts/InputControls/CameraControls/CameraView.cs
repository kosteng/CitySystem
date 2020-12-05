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