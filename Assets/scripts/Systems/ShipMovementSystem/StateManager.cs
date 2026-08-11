using UnityEngine;

public class StateManager
{
    private BaseState currentState;
    private IdleState idleState;
    private AccelerationState positveAccelerationState;
    private AccelerationState negativeAccelerationState;

    public BaseState CurrentState { get { return currentState; } set { currentState = value; } }
    public IdleState IdleState { get { return idleState; } }
    public AccelerationState PositiveAccelerationState { get { return positveAccelerationState; } }
    public AccelerationState NegativeAccelerationState { get { return negativeAccelerationState; } }

    public StateManager(bool dampen, float positiveAccelerationForce, float negativeAccelerationForce, Rigidbody rb)
    {
        idleState = new IdleState(dampen, this);
        positveAccelerationState = new AccelerationState(dampen, this, positiveAccelerationForce, rb);
        negativeAccelerationState = new AccelerationState(dampen, this, negativeAccelerationForce, rb);
        currentState = idleState;
    }
    public void UpdateState(float moveActionValue, float localV, Vector3 trans)
    {
        currentState.UpdateState(moveActionValue, localV, trans);
    }
}
