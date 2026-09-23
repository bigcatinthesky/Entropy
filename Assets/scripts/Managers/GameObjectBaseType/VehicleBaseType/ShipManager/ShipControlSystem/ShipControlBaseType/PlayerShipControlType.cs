using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerShipControlType : ShipControlBaseType
{
    [Header("Input Actions")]
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference rotate;
    [SerializeField] private InputActionReference toggleThrust;
    private ShipControlSystemManager shipControlSystemManager;
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
    void Start()
    {
        toggleThrust.action.performed += ToggleThrustPerformed;
        shipControlSystemManager = GetComponent<ShipControlSystemManager>();
    }
    void Update()
    {
        moveOutput = move.action.ReadValue<Vector3>();
        rotateOutput = rotate.action.ReadValue<Vector3>();
    }
    void ToggleThrustPerformed(InputAction.CallbackContext context)
    {
        shipControlSystemManager.ShipManager.ShipMovementSystem.SMSStateManager.ToggleOnOff();
    }
}
