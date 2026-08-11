using UnityEngine;
using UnityEngine.SocialPlatforms;

public class IdleRotationState : RotationBaseState
{
    public IdleRotationState(RotationStateManager rotationStateManager) : base(rotationStateManager) { }
    public override void UpdateState(float rotationActionValue, float localT, Vector3 trans)
    {
        if (rotationActionValue > 0 || localT < 0)
        {
            RotationBaseState positveRotationState = rotationStateManager.PositveRotationState;
            SwitchState(positveRotationState);
        }
        else if (rotationActionValue < 0 || localT > 0)
        {
            RotationBaseState negativeRotationState = rotationStateManager.NegativeRotationState;
            SwitchState(negativeRotationState);
        }
    }
}
