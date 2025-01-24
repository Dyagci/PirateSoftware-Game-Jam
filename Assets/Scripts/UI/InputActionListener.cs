using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputActionListener : MonoBehaviour
{
    [SerializeField] private InputActionReference _actionReference;
    [SerializeField] private Button _activateButton;

    public UnityEvent OnInput;

    private void OnEnable()
    {
        if(_actionReference != null)
        {
            _actionReference.action.performed += Performed;
        }
    }

    private void OnDisable()
    {
        if (_actionReference != null)
        {
            _actionReference.action.performed -= Performed;
        }
    }

    private void Performed(InputAction.CallbackContext context)
    {
        OnInput.Invoke();
        _activateButton?.onClick.Invoke();
    }

    public void ForcePerform()
    {
        OnInput.Invoke();
    }
}
