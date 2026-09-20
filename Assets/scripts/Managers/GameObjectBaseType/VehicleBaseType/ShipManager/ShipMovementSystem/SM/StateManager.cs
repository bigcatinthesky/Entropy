using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    private BaseState currentState;
    private IdleState idleState;
    private PositiveAccelerationState positveAccelerationState;
    private NegativeAccelerationState negativeAccelerationState;
    public BaseState CurrentState { get { return currentState; } set { if(currentState != null) currentState.ExitState(); currentState = value; currentState.EnterState(); } }
    public IdleState IdleState { get { return idleState; } }
    public PositiveAccelerationState PositiveAccelerationState { get { return positveAccelerationState; } }
    public NegativeAccelerationState NegativeAccelerationState { get { return negativeAccelerationState; } }

    public StateManager(bool dampen, float positiveAccelerationForce, float negativeAccelerationForce, Rigidbody rb, List<ThrusterEffectInfo> positiveThrusters, 
        List<ThrusterEffectInfo> negativeThrusters, OnState smsOnState)
    {
        idleState = new IdleState(dampen, this, null, smsOnState);
        positveAccelerationState = new PositiveAccelerationState(dampen, this, positiveAccelerationForce, rb, positiveThrusters, smsOnState);
        negativeAccelerationState = new NegativeAccelerationState(dampen, this, negativeAccelerationForce, rb, negativeThrusters, smsOnState);
        CurrentState = idleState;
    }
    // public void UpdateState(float moveActionValue, float localV, Vector3 trans)
    // {
    //     currentState.UpdateState(moveActionValue, localV, trans);
    // }
}
