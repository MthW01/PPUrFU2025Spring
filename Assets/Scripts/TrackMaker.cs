using BezierSolution;
using UnityEngine;

public class TrackMaker : MonoBehaviour
{
    [SerializeField] private BezierWalkerLocomotion _locomotion;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _count;
    [SerializeField] private float _distance = 0.12f;

    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            var segment = Instantiate(_prefab, transform);
            _locomotion.AddToTail(segment.transform, _distance);
        }
    }
}
