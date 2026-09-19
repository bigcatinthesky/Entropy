using System.Collections.Generic;
using UnityEngine;

public class IdleRotationState : RotationBaseState
{
    public IdleRotationState(RotationStateManager rotationStateManager, List<ThrusterEffectInfo> rotateThrusters, OnState smsOnState) : base(rotationStateManager, rotateThrusters, smsOnState) {}
    public override void UpdateState(float rotationActionValue, float localT, Vector3 trans)
    {
        if (rotationActionValue > 0 || localT < 0)
        {
            rotationStateManager.CurrentState = rotationStateManager.PositiveTorqueState;
        }
        else if (rotationActionValue < 0 || localT > 0)
        {
            rotationStateManager.CurrentState = rotationStateManager.NegativeTorqueState;
        }
    }
    public override void EnterState()
    {
        ToggleThrusters(false);
    }
}
