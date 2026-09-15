using UnityEngine;
using System.Collections.Generic;

public class PositiveTorqueState : RotationBaseState
{
    private Rigidbody rb;
    private float torqueForce;
    public PositiveTorqueState(RotationStateManager rotationStateManager, float torqueForce, Rigidbody rb, List<ThrusterEffectInfo> rotateThrusters) : base(rotationStateManager, rotateThrusters)
    {
        this.rb = rb;
        this.torqueForce = torqueForce;
    }
    public override void UpdateState(float rotateActionValue, float localT, Vector3 trans)
    {
        if (rotateActionValue != 0)
        {
            if (rotateActionValue > 0) { ApplyTorque(rotateActionValue, trans, rb, torqueForce); }
            else { rotationStateManager.CurrentState = rotationStateManager.NegativeTorqueState; }
        }
        else if (localT != 0)
        {
            if (localT < 0) { rotationStateManager.CurrentState = rotationStateManager.NegativeTorqueState; }
            else { ApplyTorque(1, trans, rb, torqueForce); }
        }
        else if (localT == 0) {rotationStateManager.CurrentState = rotationStateManager.IdleRotationState; }
    }
    public override void EnterState()
    {
        // ToggleThrusters(true);
    }

}