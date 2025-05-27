using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateOnButton : MonoBehaviour
{
    [SerializeField] private InputAction _button;
    [SerializeField] private MonoBehaviour _target;

    private void Start()
    {
        _button.Enable();
    }

    private void OnEnable()
    {
        _button.started += HandleButton;
    }

    private void OnDisable()
    {
        _button.started -= HandleButton;
    }

    private void HandleButton(InputAction.CallbackContext context)
    {
        _target.enabled = !_target.enabled;
    }
}