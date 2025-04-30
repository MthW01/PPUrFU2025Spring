using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Claw : MonoBehaviour
{
    [SerializeField] private float _activeValue = 45f;
    [SerializeField] private float _inactiveValue;
    [SerializeField] private float _value;
    [SerializeField] private float _delta = 1f;
    [SerializeField] private Vector3 _axis = new Vector3(0, 1, 0);
    [field: SerializeField] public bool Active { get; set; }

    private float Max => Mathf.Max(_activeValue, _inactiveValue);
    private float Min => Mathf.Min(_activeValue, _inactiveValue);

    private void FixedUpdate()
    {
        var cached = _value;
        var target = Active ? _activeValue : _inactiveValue;
        if (_value > target)
        {
            _value = Mathf.Clamp(_value - _delta * Time.fixedDeltaTime, Min, Max);
        }
        else if (_value < target)
        {
            _value = Mathf.Clamp(_value + _delta * Time.fixedDeltaTime, Min, Max);
        }
        var diff = _value - cached;

        if (diff != 0)
        {
            transform.Rotate(_axis * diff);
        }
    }
}
