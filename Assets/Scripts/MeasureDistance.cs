using System.Collections;
using TMPro;
using UnityEngine;

public class MeasureDistance : MonoBehaviour
{
    [SerializeField] private TMP_Text _display;
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private string _defaultText = "No surface";
    [SerializeField] private float _scale = 1f;

    private void Update()
    {
        if (_display == null)
        {
            return;
        }
        if (Physics.Raycast(transform.position, transform.forward, out var hit, _maxDistance, _layerMask))
        {
            _display.text = hit.distance.ToString("0.00") + " cm.";
            return;
        }
        _display.text = _defaultText;
    }

    private void OnEnable()
    {
        _display.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _display.gameObject.SetActive(false);
    }
}