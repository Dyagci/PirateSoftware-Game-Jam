using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionListener : MonoBehaviour
{
    [SerializeField] private InputActionReference _actionReference;

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
    }
}
