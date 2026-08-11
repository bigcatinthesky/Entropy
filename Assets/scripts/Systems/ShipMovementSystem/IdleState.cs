using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class IdleState : BaseState
{

    public IdleState(bool dampen, StateManager stateManager) : base(stateManager, dampen) { }
    public override void UpdateState(float moveActionValue, float localV, Vector3 trans)
    {
        
        if (moveActionValue > 0 || (dampen == true && localV < 0))
        {
            BaseState positiveAccelerationState = stateManager.PositiveAccelerationState;
            SwitchState(positiveAccelerationState);
        }
        else if (moveActionValue < 0 || (dampen == true && localV > 0)) 
        {
            BaseState negativeAccelerationState = stateManager.NegativeAccelerationState;
            SwitchState(negativeAccelerationState);
        }
    }
}