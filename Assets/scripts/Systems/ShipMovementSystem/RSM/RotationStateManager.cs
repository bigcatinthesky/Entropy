using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RotationStateManager
{
    private RotationBaseState currentState;
    private IdleRotationState idleRotationState;
    private PositiveTorqueState positiveTorqueState;
    private NegativeTorqueState negativeTorqueState;

    public RotationBaseState CurrentState { get { return currentState; } set { currentState = value; currentState.EnterState(); } }
    public IdleRotationState IdleRotationState { get { return idleRotationState; } }
    public PositiveTorqueState PositiveTorqueState { get { return positiveTorqueState; } }
    public NegativeTorqueState NegativeTorqueState { get { return negativeTorqueState; } }

    public RotationStateManager(float rotationTourque, Rigidbody rb, List<ThrusterEffectInfo> positiveRotateThrusters, List<ThrusterEffectInfo> negativeRotateThrusters)
    {
        List<ThrusterEffectInfo> allThursters = new List<ThrusterEffectInfo>(negativeRotateThrusters.Count+positiveRotateThrusters.Count);
        allThursters.AddRange(positiveRotateThrusters);
        allThursters.AddRange(negativeRotateThrusters);
        idleRotationState = new IdleRotationState(this, allThursters);
        positiveTorqueState = new PositiveTorqueState(this, rotationTourque, rb, positiveRotateThrusters);
        negativeTorqueState = new NegativeTorqueState(this, rotationTourque, rb, negativeRotateThrusters);
        CurrentState = idleRotationState;
    }
    // public void UpdateState(float rotationActionValue, float localT, Vector3 trans)
    // {
    //     currentState.UpdateState(rotationActionValue, localT, trans);
    // }
}

