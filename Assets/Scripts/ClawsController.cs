using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClawsController : MonoBehaviour
{
    [SerializeField] private InputAction _toggle;
    [SerializeField] private bool _state;
    [SerializeField] private Claw _clawTop;
    [SerializeField] private Claw _clawBottom;

    private void Start()
    {
        _toggle.Enable();
    }

    private void OnEnable()
    {
        _toggle.started += HandleToggle;
    }

    private void OnDisable()
    {
        _toggle.started -= HandleToggle;
    }

    private void HandleToggle(InputAction.CallbackContext context)
    {
        _state = !_state;
        _clawTop.Active = _state;
        _clawBottom.Active = _state;
    }
}