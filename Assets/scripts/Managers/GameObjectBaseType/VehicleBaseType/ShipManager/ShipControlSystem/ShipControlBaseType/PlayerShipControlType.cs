using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerShipControlType : ShipControlBaseType
{
    [Header("Input Actions")]
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference rotate;
    [SerializeField] private InputActionReference toggleThrust;
    private void OnEnable()
    {
        move.action.Enable();
        rotate.action.Enable();
        toggleThrust.action.Enable();
    }
    private void OnDisable()
    {
        move.action.Disable();
        rotate.action.Disable();
        toggleThrust.action.Disable();
    }

    private void FixedUpdate()
    {
        moveOutput = move.action.ReadValue<Vector3>();
        rotateOutput = rotate.action.ReadValue<Vector3>();
        toggleThrustOutput = toggleThrust.action.IsPressed();
        // Debug.Log(toggleThrust.action.IsPressed()); 
    }
}
