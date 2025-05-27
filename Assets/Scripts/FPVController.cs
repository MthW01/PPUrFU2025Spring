using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPVController : MonoBehaviour
{
    [SerializeField] private InputAction _look;
    [SerializeField] private Transform _rotationHorizontal;
    [SerializeField] private Transform _rotationVertical;
    [SerializeField] private float _FOVLimitX;
    [SerializeField] private float _sensitivity;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _max = 1f;
    [SerializeField] private float _min = -1f;
    [SerializeField] private float _rotationSpeedLimit;
    private float _vertical = 0;

    public float SpeedLimitScaled => _rotationSpeedLimit * Time.deltaTime;

    private void Start()
    {
        _look.Enable();
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _camera.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _camera.gameObject.SetActive(false);
    }

    private void Update()
    {
        var delta = ApplyLimit(_look.ReadValue<Vector2>() * _sensitivity);

        RotateVertical(-delta.y);

        _rotationHorizontal.Rotate(new Vector3(0, 0, delta.x));
    }

    private void RotateVertical(float delta)
    {
        var cached = _vertical;

        _vertical = Mathf.Clamp(_vertical + delta, _min, _max);

        var diff = _vertical - cached;

        if (diff != 0)
        {
            _rotationVertical.Rotate(0, diff, 0);
        }
    }

    private Vector2 ApplyLimit(Vector2 delta)
    {
        if (delta.magnitude < SpeedLimitScaled)
        {
            return delta;
        }
        else
        {
            return delta.normalized * SpeedLimitScaled;
        }
    }
}
