using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [field: Header("Components")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GameObject _humanSprite;
    [SerializeField] private GameObject _zombieSprite;

    [field: Header("ZombieStats")]
    [SerializeField] private float _zombieSpeed = 1.0f;
    [SerializeField] private float _zombieSpeedMax = 3.0f;
    [SerializeField] private float _zombieAcceleration = 5.0f;

    [field: Header("HumanStats")]
    [SerializeField] private float _humanSpeed = 1.0f;
    [SerializeField] private float _humanSpeedMax = 3.0f;
    [SerializeField] private float _humanAcceleration = 5.0f;


    [field: Header("General")]
    [SerializeField] private bool _canMove = true;
    [SerializeField] private bool _isZombie = true;

    private float _speed;
    private float _speedMax;
    private float _acceleration;
    private Vector2 _targetPos;

    private void OnValidate()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _targetPos = transform.position;
        StateCheck();
    }

    private void StateCheck()
    {
        _zombieSprite.SetActive(_isZombie);
        _humanSprite.SetActive(!_isZombie);
        if (_isZombie)
        {
            _speed = _zombieSpeed;
            _speedMax = _zombieSpeedMax;
            _acceleration = _zombieAcceleration;
        }
        else
        {
            _speed = _humanSpeed;
            _speedMax = _humanSpeedMax;
            _acceleration = _humanAcceleration;
        }
    }

    private void Update()
    {
        //target overridden to mouseposition during leftclick
        if (Input.GetMouseButton(0) && _isZombie)
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

        //Debug.Log($"Current location: {_rb.position}");
        //Debug.Log($"Target location: {_targetPos}");
        //Debug.Log($"Velocity: {_rb.linearVelocity}");
    }

    private void MoveTowardsTarget()
    {
        Vector2 direction = (_targetPos - _rb.position);

        // calculates desirection movement velocity
        Vector2 targetVelocity = direction * _zombieSpeed;
        if (!_canMove) targetVelocity = Vector2.zero;

        // calculates acceleration required to reach desired velocity
        Vector2 velocityDiff = targetVelocity - _rb.linearVelocity;
        Vector2 acceleration = velocityDiff * _zombieAcceleration;

        _rb.AddForce(acceleration * _rb.mass);
        
        //slow if reaches max speed
        if (_rb.linearVelocity.magnitude > _zombieSpeedMax) _rb.linearVelocity = Vector2.ClampMagnitude(_rb.linearVelocity, _zombieSpeedMax);
    }

    private void AcquireTarget()
    { 
        
    }
}
