using UnityEngine;
using UnityEngine.InputSystem;

public class HorizontalMovement : MonoBehaviour
{
    public bool MoveForwardThisFrame = false;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private InputAction _moveForward;
    [SerializeField] private InputAction _moveBackward;
    [SerializeField] private float _decceleration = 1f;
    [Header("Forward")]
    [SerializeField] private float _accelerationForward = 1f;
    [SerializeField] private float _maxSpeedForward = 1f;
    [Header("Backward")]
    [SerializeField] private float _accelerationBackward = 1f;
    [SerializeField] private float _maxSpeedBackward = 1f;
    public float Speed { get; private set; } = 0;

    private void Start()
    {
        _moveForward.Enable();
        _moveBackward.Enable();
    }

    void FixedUpdate()
    {
        if (_moveForward.IsPressed() || MoveForwardThisFrame)
        {
            Speed = Mathf.Clamp(Speed + _accelerationForward, -_maxSpeedBackward, _maxSpeedForward);
        }
        if (_moveBackward.IsPressed())
        {
            Speed = Mathf.Clamp(Speed - _accelerationBackward, -_maxSpeedBackward, _maxSpeedForward);
        }

        if (Speed > 0)
        {
            Speed = Mathf.Clamp(Speed - _decceleration, 0, _maxSpeedForward);
        }
        else if (Speed < 0)
        {
            Speed = Mathf.Clamp(Speed + _decceleration, -_maxSpeedBackward, 0);
        }

        if (Speed != 0)
        {
            //transform.position += transform.forward * Speed * Time.fixedDeltaTime;
            _rb.linearVelocity = transform.forward * Speed * Time.fixedDeltaTime * 100f;
        }
        else
        {
            _rb.linearVelocity = Vector3.zero;
        }
        MoveForwardThisFrame = false;
    }
}
