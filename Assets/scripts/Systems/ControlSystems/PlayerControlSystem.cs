using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlSystem : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputActionReference shipMove;
    [SerializeField] private InputActionReference shipRotate;

    private void OnEnable()
    {
        shipMove.action.Enable();
        shipRotate.action.Enable();
    }

    private void OnDisable()
    {
        shipMove.action.Disable();
        shipRotate.action.Disable();
    }
}
