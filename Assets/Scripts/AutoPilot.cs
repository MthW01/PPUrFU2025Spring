using BezierSolution;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AutoPilot : MonoBehaviour
{
    [SerializeField] private BezierSpline _spline;
    [SerializeField] private Transform _origin;
    [SerializeField] private AxisRotation _rotation;
    [SerializeField] private HorizontalMovement _movement;
    [SerializeField] private float _maxStraightAngle;
    [SerializeField] private GameObject _label;

    private Vector2 Origin2D => new Vector2(_origin.position.x, _origin.position.z);

    private void Update()
    {
        var target = _spline.FindNearestPointTo(transform.position);
        var target2d = new Vector2(target.x, target.z);
        var difference2d = target2d - Origin2D;
        var difference = new Vector3(difference2d.x, 0, difference2d.y);
        var targetAngle = Quaternion.LookRotation(difference, Vector3.up).eulerAngles.y;
        var angle = Mathf.DeltaAngle(_origin.eulerAngles.y, targetAngle);
        Debug.Log(angle);
        if (Mathf.Abs(angle) < _maxStraightAngle)
        {
            _movement.MoveForwardThisFrame = true;
        }
        else if (angle > 0)
        {
            _rotation.IncreaceThisFrame = true;
        }
        else
        {
            _rotation.DecreaceThisFrame = true;
        }
    }

    private void OnEnable()
    {
        _label.SetActive(true);
    }

    private void OnDisable()
    {
        _label.SetActive(false);
    }
}