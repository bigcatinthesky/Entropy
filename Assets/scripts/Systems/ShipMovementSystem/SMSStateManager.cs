using System.Collections.Generic;
using UnityEngine;

public class SMSStateManager
{
    private SMSBaseState currentState;
    private OnState onState;
    private OffState offState;
    public SMSBaseState CurrentState { get { return currentState; } set { currentState = value; } }
    public OnState OnState { get { return onState; } }
    public OffState OffState{ get { return offState; } }

    public SMSStateManager(ShipMovementSystem shipMovementSystem, Dictionary<string,List<ThrusterEffectInfo>> moveThrusters)
    {
        offState = new OffState(this, moveThrusters);
        onState = new OnState(shipMovementSystem, this, moveThrusters);
        currentState = offState;
    }
    public void UpdateState(bool doMove)
    {
        currentState.UpdateState(doMove);
    }
}
