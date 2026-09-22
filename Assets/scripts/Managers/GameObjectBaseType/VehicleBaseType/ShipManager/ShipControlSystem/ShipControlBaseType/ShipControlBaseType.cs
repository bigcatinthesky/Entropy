using UnityEngine;

public abstract class ShipControlBaseType : MonoBehaviour
{
    protected Vector3 moveOutput;
    protected Vector3 rotateOutput;
    protected bool toggleThrustOutput;
    public Vector3 MoveOutput { get { return moveOutput; } }
    public Vector3 RotateOutput { get { return rotateOutput; } }
    public bool ToggleThrustOutput { get { return toggleThrustOutput; } }
}
