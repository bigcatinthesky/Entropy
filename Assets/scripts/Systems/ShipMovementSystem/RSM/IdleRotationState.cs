using UnityEngine;

public class IdleRotationState : RotationBaseState
{
    public IdleRotationState(RotationStateManager rotationStateManager) : base(rotationStateManager) {}
    public override void UpdateState(float rotationActionValue, float localT, Vector3 trans)
    {
        if (rotationActionValue > 0 || localT < 0)
        {
            SwitchState(rotationStateManager.PositiveTorqueState);
        }
        else if (rotationActionValue < 0 || localT > 0)
        {
            SwitchState(rotationStateManager.NegativeTorqueState);
        }
    }
    public override void EnterState() {}
    public override void ExitState() {}
}
