using UnityEngine;

public abstract class RotationBaseState
{
    protected RotationStateManager rotationStateManager;
    protected RotationBaseState(RotationStateManager rotationStateManager)
    {
        this.rotationStateManager = rotationStateManager;
    }
    public abstract void UpdateState(float rotationActionValue, float localT, Vector3 trans);
    protected void EnterState()
    {
        rotationStateManager.CurrentState = this;
    }
    protected void SwitchState(RotationBaseState newState)
    {
        newState.EnterState();
    }
}
