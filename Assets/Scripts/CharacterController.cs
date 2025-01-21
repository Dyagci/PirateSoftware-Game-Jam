using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _acceleration = 0.1f;

    private Vector2 _targetPos;

    UnityEvent m_LeftClick;

    public void Walk(Vector2 moveTarget, float moveSpeed)
    {
        //_rb.AddForce( * _acceleration)
    }

    private void Start()
    {
        _targetPos = transform.position;

        //if (m_LeftClick == null)
        //    m_LeftClick = new UnityEvent();

        //m_LeftClick.AddListener(MouseTarget);
    }

    private void Update()
    {
        //target acquired when within detection range
        //AcquireTarget()

        //target overridden to mouseposition during leftclick
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetPos = mousePosition;
        }
    }


    private void FixedUpdate()
    {
        //while has target, moves towards target
        MoveTowardsTarget();

        Debug.Log($"Current location: {_rb.position}");
        Debug.Log($"Target location: {_targetPos}");
        Debug.Log($"Velocity: {_rb.linearVelocity}");
    }

    private void MoveTowardsTarget()
    {
        Vector2 direction = (_targetPos - _rb.position);

        _rb.AddForce(direction * _acceleration);
    }

    private void AcquireTarget()
    { 
    
    }
}
