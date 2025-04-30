using BezierSolution;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSyncronizer : MonoBehaviour
{
    [SerializeField] private Vector3 _wheelAxis = new Vector3(0, 1, 0);
    [SerializeField] private float _wheelModifier = 50f;
    [SerializeField] private HorizontalMovement _movement;
    [SerializeField] private List<BezierWalkerWithSpeed> _walkers;
    [SerializeField] private List<Transform> _wheels;

    private void FixedUpdate()
    {
        foreach (var walker in _walkers)
        {
            walker.speed = _movement.Speed;
        }

        foreach (var wheel in _wheels)
        {
            wheel.Rotate(_wheelAxis * _wheelModifier * _movement.Speed * Time.fixedDeltaTime);
        }
    }
}