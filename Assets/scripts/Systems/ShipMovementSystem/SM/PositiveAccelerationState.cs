using UnityEngine;
using System.Collections.Generic;

public class PositiveAccelerationState : BaseState
{
    private float accelerationForce;
    private Rigidbody rb;
    public PositiveAccelerationState(bool dampen, StateManager stateManager, float accelerationForce, Rigidbody rb, List<ThrusterEffectInfo> moveThrusters) : base(stateManager, dampen, moveThrusters)
    {
        this.accelerationForce = accelerationForce;
        this.rb = rb;
    }
    public override void UpdateState(float moveActionValue, float localV, Vector3 trans)
    {
        if (moveActionValue != 0)
        {
            if (moveActionValue > 0) { Accelerate(moveActionValue, trans, rb, accelerationForce); }
            else { stateManager.CurrentState = stateManager.NegativeAccelerationState; }
        }
        else if(dampen == true && localV != 0)
        {
            if (localV < 0) { stateManager.CurrentState = stateManager.NegativeAccelerationState; }
            else { Accelerate(1, trans, rb, accelerationForce); }
        }
        else if(dampen == false || localV == 0) { stateManager.CurrentState = stateManager.IdleState; }
    }
    public override void EnterState()
    {
        // SetThrusterLength(4, moveThrusters);
    }
}
