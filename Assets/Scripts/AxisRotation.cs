using UnityEngine;
using UnityEngine.InputSystem;

public class AxisRotation : MonoBehaviour
{
    [SerializeField] public InputAction Increase;
    [SerializeField] public InputAction Decreace;
    [SerializeField] public bool IncreaceThisFrame = false;
    [SerializeField] public bool DecreaceThisFrame = false;
    [SerializeField] private float _delta = 1f;
    [SerializeField] private float _max = 1f;
    [SerializeField] private float _min = -1f;
    [SerializeField] private Vector3 _axis = new Vector3(0, 1, 0);
    [SerializeField] private float _value = 0f;

    private void Start()
    {
        Increase.Enable();
        Decreace.Enable();
    }

    void FixedUpdate()
    {
        var cached = _value;
        if (Increase.IsPressed() || IncreaceThisFrame)
        {
            _value = Mathf.Clamp(_value + _delta * Time.fixedDeltaTime, _min, _max);
        }
        if (Decreace.IsPressed() || DecreaceThisFrame)
        {
            _value = Mathf.Clamp(_value - _delta * Time.fixedDeltaTime, _min, _max);
        }
        var diff = _value - cached;

        if (diff != 0)
        {
            transform.Rotate(_axis * diff);
        }
        IncreaceThisFrame = false;
        DecreaceThisFrame = false;
    }
}
