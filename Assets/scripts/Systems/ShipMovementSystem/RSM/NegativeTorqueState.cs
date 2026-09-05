using UnityEngine;
using System.Collections.Generic;

public class NegativeTorqueState : RotationBaseState
{
    private Rigidbody rb;
    private float torqueForce;
    private List<ThrusterEffectInfo> rotateThrusters;
    public NegativeTorqueState(RotationStateManager rotationStateManager, float torqueForce, Rigidbody rb, List<ThrusterEffectInfo> rotateThrusters) : base(rotationStateManager)
    {
        this.rb = rb;
        this.torqueForce = torqueForce;
        this.rotateThrusters = rotateThrusters;
    }
    public override void UpdateState(float rotateActionValue, float localT, Vector3 trans)
    {
        if (rotateActionValue != 0)
        {
            if (rotateActionValue < 0) { ApplyTorque(rotateActionValue, trans, rb, torqueForce); }
            else { SwitchState(rotationStateManager.PositiveTorqueState); }
        }
        else if (localT != 0)
        {
            if (localT > 0) {SwitchState(rotationStateManager.PositiveTorqueState); }
            else { ApplyTorque(-1, trans, rb, torqueForce); }
        }
        else if (localT == 0) { SwitchState(rotationStateManager.IdleRotationState); }
    }
    public override void EnterState()
    {
        SetThrusterLength(4, rotateThrusters);
    }
    public override void ExitState()
    {
        SetThrusterLength(0, rotateThrusters);
    }

}