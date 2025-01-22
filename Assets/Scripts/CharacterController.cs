using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _speedMax = 3.0f;
    [SerializeField] private float _acceleration = 5.0f;
    [SerializeField] private bool _canMove = true;

    private Vector2 _targetPos;

    private void OnValidate()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _targetPos = transform.position;
    }

    private void Update()
    {
        //target overridden to mouseposition during leftclick
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetPos = mousePosition;
        }
    }


    private void FixedUpdate()
    {
        //target acquired when within detection range
        //AcquireTarget()

        //while has target, moves towards target
        MoveTowardsTarget();

        Debug.Log($"Current location: {_rb.position}");
        Debug.Log($"Target location: {_targetPos}");
        Debug.Log($"Velocity: {_rb.linearVelocity}");
    }

    private void MoveTowardsTarget()
    {
        Vector2 direction = (_targetPos - _rb.position);

        // calculates desirection movement velocity
        Vector2 targetVelocity = direction * _speed;
        if (!_canMove) targetVelocity = Vector2.zero;

        // calculates acceleration required to reach desired velocity
        Vector2 velocityDiff = targetVelocity - _rb.linearVelocity;
        Vector2 acceleration = velocityDiff * _acceleration;

        _rb.AddForce(acceleration * _rb.mass);
        
        //slow if reaches max speed
        if (_rb.linearVelocity.magnitude > _speedMax) _rb.linearVelocity = Vector2.ClampMagnitude(_rb.linearVelocity, _speedMax);
    }

    private void AcquireTarget()
    { 
        
    }
}
