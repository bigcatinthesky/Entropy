using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipControlSystem : ShipControlBaseType
{
    [Header("Input Actions")]
    [SerializeField] private bool doMove;
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference rotate;
    void Start()
    {
        
    }
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
    void FixedUpdate()
    {
        
    }
}
