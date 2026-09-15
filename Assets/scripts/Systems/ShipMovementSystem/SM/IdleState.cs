using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class IdleState : BaseState
{

    public IdleState(bool dampen, StateManager stateManager, List<ThrusterEffectInfo> moveThrusters) : base(stateManager, dampen, moveThrusters) {}
    public override void UpdateState(float moveActionValue, float localV, Vector3 trans)
    {
        
        if (moveActionValue > 0 || (dampen == true && localV < 0))
        {
           stateManager.CurrentState = stateManager.PositiveAccelerationState;;
        }
        else if (moveActionValue < 0 || (dampen == true && localV > 0)) 
        {
            stateManager.CurrentState = stateManager.NegativeAccelerationState;;
        }
    }
    public override void EnterState() {}
}