using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipControlType : ShipControlBaseType
{
    [Header("Input Actions")]
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference rotate;

    private void OnEnable()
    {
        move.action.Enable();
        rotate.action.Enable();
    }

    private void OnDisable()
    {
        move.action.Disable();
        rotate.action.Disable();
    }

    private void FixedUpdate()
    {
        moveOutput = move.action.ReadValue<Vector3>();
        rotateOutput = rotate.action.ReadValue<Vector3>();
    }
}
