using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RotationStateManager
{
    private RotationBaseState currentState;
    private IdleRotationState idleRotationState;
    private PositiveTorqueState positiveTorqueState;
    private NegativeTorqueState negativeTorqueState;

    public RotationBaseState CurrentState { get { return currentState; } set { if(currentState != null) currentState.ExitState(); currentState = value; currentState.EnterState(); } }
    public IdleRotationState IdleRotationState { get { return idleRotationState; } }
    public PositiveTorqueState PositiveTorqueState { get { return positiveTorqueState; } }
    public NegativeTorqueState NegativeTorqueState { get { return negativeTorqueState; } }

    public RotationStateManager(float rotationTourque, Rigidbody rb, List<ThrusterEffectInfo> positiveRotateThrusters, List<ThrusterEffectInfo> negativeRotateThrusters, OnState smsOnState)
    {
        idleRotationState = new IdleRotationState(this, null, smsOnState);
        positiveTorqueState = new PositiveTorqueState(this, rotationTourque, rb, positiveRotateThrusters, smsOnState);
        negativeTorqueState = new NegativeTorqueState(this, rotationTourque, rb, negativeRotateThrusters, smsOnState);
        CurrentState = idleRotationState;
    }
    // public void UpdateState(float rotationActionValue, float localT, Vector3 trans)
    // {
    //     currentState.UpdateState(rotationActionValue, localT, trans);
    // }
}

