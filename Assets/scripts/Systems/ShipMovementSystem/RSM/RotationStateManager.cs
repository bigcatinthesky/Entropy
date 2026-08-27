using UnityEngine;

public class RotationStateManager
{
    private RotationBaseState currentState;
    private IdleRotationState idleRotationState;
    private ActiveRotationState positveRotationState;
    private ActiveRotationState negativeRotationState;

    public RotationBaseState CurrentState { get { return currentState; } set { currentState = value; } }
    public IdleRotationState IdleRotationState { get { return idleRotationState; } }
    public ActiveRotationState PositveRotationState { get { return positveRotationState; } }
    public ActiveRotationState NegativeRotationState { get { return negativeRotationState; } }

    public RotationStateManager(float rotationTourque, Rigidbody rb)
    {
        idleRotationState = new IdleRotationState(this);
        positveRotationState = new ActiveRotationState(this, rotationTourque, rb);
        negativeRotationState = new ActiveRotationState(this, rotationTourque, rb);
        currentState = idleRotationState;
    }
    public void UpdateState(float rotationActionValue, float localT, Vector3 trans)
    {
        currentState.UpdateState(rotationActionValue, localT, trans);
    }
}

