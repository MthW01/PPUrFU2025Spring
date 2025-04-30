using UnityEngine;
using UnityEngine.InputSystem;

public class AxisRotation : MonoBehaviour
{
    [SerializeField] private InputAction _increase;
    [SerializeField] private InputAction _decreace;
    [SerializeField] private float _delta = 1f;
    [SerializeField] private float _max = 1f;
    [SerializeField] private float _min = -1f;
    [SerializeField] private Vector3 _axis = new Vector3(0, 1, 0);
    [SerializeField] private float _value = 0f;

    private void Start()
    {
        _increase.Enable();
        _decreace.Enable();
    }

    void FixedUpdate()
    {
        var cached = _value;
        if (_increase.IsPressed())
        {
            _value = Mathf.Clamp(_value + _delta * Time.fixedDeltaTime, _min, _max);
        }
        if (_decreace.IsPressed())
        {
            _value = Mathf.Clamp(_value - _delta * Time.fixedDeltaTime, _min, _max);
        }
        var diff = _value - cached;

        if (diff != 0)
        {
            transform.Rotate(_axis * diff);
        }
    }
}
