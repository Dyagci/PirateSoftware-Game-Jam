using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _edgeScrollThreshold;
    [SerializeField] private float _cameraSpeed;

    private Vector3 _moveDirection;
    private Vector3 _inputDirection;

    private void Update()
    {
        _inputDirection = Vector3.zero;
        if (Input.mousePosition.x < _edgeScrollThreshold)
        {
            _inputDirection.x = -1;
        }

        if (Input.mousePosition.y < _edgeScrollThreshold)
        {
            _inputDirection.y = -1;
        }

        if (Input.mousePosition.x > Screen.width - _edgeScrollThreshold)
        {
            _inputDirection.x = 1;
        }

        if (Input.mousePosition.y > Screen.height - _edgeScrollThreshold)
        {
            _inputDirection.y = 1;
        }

        _moveDirection = transform.up * _inputDirection.y + transform.right * _inputDirection.x;
        _camera.transform.position += _moveDirection * _cameraSpeed * Time.deltaTime;
    }
}
