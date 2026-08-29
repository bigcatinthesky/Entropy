using UnityEngine;
using System.Collections.Generic;

public class RotationStateManager
{
    private RotationBaseState currentState;
    private IdleRotationState idleRotationState;
    private PositiveTorqueState positiveTorqueState;
    private NegativeTorqueState negativeTorqueState;

    public RotationBaseState CurrentState { get { return currentState; } set { currentState = value; } }
    public IdleRotationState IdleRotationState { get { return idleRotationState; } }
    public PositiveTorqueState PositiveTorqueState { get { return positiveTorqueState; } }
    public NegativeTorqueState NegativeTorqueState { get { return negativeTorqueState; } }

    public RotationStateManager(float rotationTourque, Rigidbody rb, List<ThrusterEffectInfo> positiveRotateThrusters, List<ThrusterEffectInfo> negativeRotateThrusters)
    {
        idleRotationState = new IdleRotationState(this);
        positiveTorqueState = new PositiveTorqueState(this, rotationTourque, rb, positiveRotateThrusters);
        negativeTorqueState = new NegativeTorqueState(this, rotationTourque, rb, negativeRotateThrusters);
        idleRotationState.InitStartState();
    }
    public void UpdateState(float rotationActionValue, float localT, Vector3 trans)
    {
        currentState.UpdateState(rotationActionValue, localT, trans);
    }
}

