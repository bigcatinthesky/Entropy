using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class IdleState : BaseState
{

    public IdleState(bool dampen, StateManager stateManager) : base(stateManager, dampen) {}
    public override void UpdateState(float moveActionValue, float localV, Vector3 trans)
    {
        
        if (moveActionValue > 0 || (dampen == true && localV < 0))
        {
            SwitchState(stateManager.PositiveAccelerationState);
        }
        else if (moveActionValue < 0 || (dampen == true && localV > 0)) 
        {
            SwitchState(stateManager.NegativeAccelerationState);
        }
    }
    protected override void EnterState() {}
    protected override void ExitState() {}
}