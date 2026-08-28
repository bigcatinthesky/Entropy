using UnityEngine;
using System.Collections.Generic;

public class PositiveAccelerationState : BaseState
{
    private float accelerationForce;
    private Rigidbody rb;
    private List<ThrusterEffectInfo> moveThrusters;
    public PositiveAccelerationState(bool dampen, StateManager stateManager, float accelerationForce, Rigidbody rb, List<ThrusterEffectInfo> moveThrusters) : base(stateManager, dampen)
    {
        this.accelerationForce = accelerationForce;
        this.rb = rb;
        this.moveThrusters = moveThrusters;
    }
    public override void UpdateState(float moveActionValue, float localV, Vector3 trans)
    {

        if (moveActionValue != 0)
        {
            Accelerate(moveActionValue, trans);
        }
        else if(dampen == true && localV != 0)
        {
            
        }
        else if(dampen == false || localV == 0)
        {
            SwitchState(stateManager.IdleState);
        }
    }
    protected override void EnterState()
    {
        SetThrusterLength(4, moveThrusters);
    }
    protected override void ExitState()
    {
        SetThrusterLength(0, moveThrusters);
    }
    private void Accelerate(float moveActionValue, Vector3 trans)
    {
        rb.AddForce(trans * Time.fixedDeltaTime * accelerationForce * moveActionValue*-1, ForceMode.Acceleration);
    }


}
