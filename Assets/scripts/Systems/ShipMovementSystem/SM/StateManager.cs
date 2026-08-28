using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    private BaseState currentState;
    private IdleState idleState;
    private PositiveAccelerationState positveAccelerationState;
    private NegativeAccelerationState negativeAccelerationState;

    public BaseState CurrentState { get { return currentState; } set { currentState = value; } }
    public IdleState IdleState { get { return idleState; } }
    public PositiveAccelerationState PositiveAccelerationState { get { return positveAccelerationState; } }
    public NegativeAccelerationState NegativeAccelerationState { get { return negativeAccelerationState; } }

    public StateManager(bool dampen, float positiveAccelerationForce, float negativeAccelerationForce, Rigidbody rb, List<ThrusterEffectInfo> positiveThrusters, List<ThrusterEffectInfo> negativeThrusters)
    {
        Debug.Log(positiveThrusters.Count);
        Debug.Log(negativeThrusters.Count);
        idleState = new IdleState(dampen, this);
        positveAccelerationState = new PositiveAccelerationState(dampen, this, positiveAccelerationForce, rb, positiveThrusters);
        negativeAccelerationState = new NegativeAccelerationState(dampen, this, negativeAccelerationForce, rb, negativeThrusters);
        idleState.InitStartState();
    }
    public void UpdateState(float moveActionValue, float localV, Vector3 trans)
    {
        currentState.UpdateState(moveActionValue, localV, trans);
    }
}
